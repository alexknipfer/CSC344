package sample;

import javafx.beans.value.ChangeListener;
import javafx.beans.value.ObservableValue;
import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.geometry.Insets;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.ProgressIndicator;
import javafx.scene.control.TextField;
import javafx.scene.input.MouseEvent;
import javafx.scene.layout.HBox;
import javafx.scene.layout.StackPane;
import javafx.scene.layout.VBox;
import javafx.scene.web.WebEngine;
import javafx.scene.web.WebEvent;
import javafx.scene.web.WebView;
import javafx.stage.Modality;
import javafx.concurrent.Worker.State;


import java.util.ArrayList;
import java.util.List;


/**
 * Created by alexknipfer on 10/16/15.
 */
public class WebViewBox extends VBox {

    private WebView browser;
    private WebEngine engine;
    private ProgressIndicator indicator;
    private StackPane holder;
    private TextField scriptField;
    public AlertBox myAlert;

        //list keeps all web added from file
    public static List<WebView> myWebs = new ArrayList<WebView>();

    public WebViewBox(String url, String title){
            //This constructor calls method to build web container
            //given the link of the website and title

        buildVBox(url, 150, title);
    }

    private void buildVBox(String loadURL, int webWidth, String title){

            //This method builds the web box container given the URL,
            // width of web view, and the title

            //build label with given title
        Label webTitle = new Label(title);

            //space to line up with web view
        webTitle.setPadding(new Insets(0,0,0,40));

            //build new browser and get web engine
        browser = new WebView();
        engine = browser.getEngine();

            //add to web list
        myWebs.add(browser);

            //set width of web box
        browser.setMaxWidth(webWidth);

            //make height same as width for box shape
        browser.setMaxHeight(webWidth);

            //build new indicator for when web page loads
        indicator = new ProgressIndicator();

            //decrease default size of indicator
        indicator.setMaxHeight(0.1 * webWidth);
        indicator.setMaxWidth(0.1 * webWidth);

            //build holder for the browser and indicator
        holder = new StackPane();
        holder.getChildren().add(browser);
        holder.getChildren().add(indicator);

            //double the size of the web view when hovering mouse over
        browser.addEventHandler(MouseEvent.MOUSE_ENTERED_TARGET, new EventHandler<MouseEvent>() {

            @Override
            public void handle(MouseEvent event) {
                browser.setMinWidth(browser.getWidth() * 2);

            }
        });

            //bring the size of web back to default after moving mouse off of video
        browser.addEventHandler(MouseEvent.MOUSE_EXITED_TARGET, new EventHandler<MouseEvent>() {

            @Override
            public void handle(MouseEvent event) {
                browser.setMinWidth(browser.getWidth() / 2);

            }
        });

            //build controls box for textfield and button
        HBox controls = new HBox();

            //text field for javascript to be typed in from user
        scriptField = new TextField();
        scriptField.setPromptText("Script");

            //build "inject" button
        Button inject = new Button("INJ");

            //create handler to execute javascript on webpage from user data
        EventHandler<ActionEvent> myEventHandler =
                new EventHandler<ActionEvent>()
                {
                    @Override
                    public void handle(ActionEvent ev)
                    {
                        engine.executeScript(scriptField.getText());
                    }
                };

            //do the script given from user upon clicking "inject" button
        inject.setOnAction(myEventHandler);

            //create handler to allow javascript "alert" to prompt on program
        EventHandler<WebEvent<String>> webEV =
                new EventHandler<WebEvent<String>>()
                {
                    @Override
                    public void handle(WebEvent<String> ev)
                    {
                            //get data (alert) from user
                        String data = ev.getData();

                            //build slert box and show
                        myAlert = new AlertBox(data);

                            //don't allow user to click outside alert box until closing it
                        myAlert.initModality(Modality.APPLICATION_MODAL);
                        myAlert.showAndWait();
                    }
                };

            //set alert from script to web engine
        engine.setOnAlert(webEV);

            //get website load progress for indicator
        engine.getLoadWorker().stateProperty().addListener(
                new ChangeListener<State>() {
                    @Override
                    public void changed(ObservableValue<? extends State> obs, State oldState, State newState) {

                            //once website has loaded remove the indicator to show
                            //it's completely loaded
                        if (newState == State.SUCCEEDED) {
                            holder.getChildren().remove(indicator);
                        }
                    }
                }
        );


            //add text field and button to controls box
        controls.getChildren().addAll(scriptField, inject);

            //add everything to web view box (container)
        this.getChildren().addAll(webTitle,holder, controls);

            //load given URL
        engine.load(loadURL);
    }

}
