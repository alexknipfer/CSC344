package sample;

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
import javafx.scene.media.MediaView;
import javafx.scene.web.WebEngine;
import javafx.scene.web.WebEvent;
import javafx.scene.web.WebView;
import javafx.stage.Modality;

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

    public static List<WebView> myWebs = new ArrayList<WebView>();

    public WebViewBox(String url, String title){

        buildVBox(url, 150, title);
    }

    private void buildVBox(String loadURL, int webWidth, String title){

        Label webTitle = new Label(title);
        webTitle.setPadding(new Insets(0,0,0,40));

        browser = new WebView();
        engine = browser.getEngine();

        myWebs.add(browser);

        browser.setMaxWidth(webWidth);
        browser.setMaxHeight(webWidth);

        holder = new StackPane();
        holder.getChildren().add(browser);

        browser.addEventHandler(MouseEvent.MOUSE_ENTERED_TARGET, new EventHandler<MouseEvent>() {

            @Override
            public void handle(MouseEvent event) {
                browser.setMinWidth(browser.getWidth() * 2);

            }
        });

        browser.addEventHandler(MouseEvent.MOUSE_EXITED_TARGET, new EventHandler<MouseEvent>() {

            @Override
            public void handle(MouseEvent event) {
                browser.setMinWidth(browser.getWidth() / 2);

            }
        });

        HBox controls = new HBox();
        scriptField = new TextField();
        scriptField.setPromptText("Script");

        Button inject = new Button("INJ");

        EventHandler<ActionEvent> myEventHandler =
                new EventHandler<ActionEvent>()
                {
                    @Override
                    public void handle(ActionEvent ev)
                    {
                        engine.executeScript(scriptField.getText());
                    }
                };
        inject.setOnAction(myEventHandler);

        EventHandler<WebEvent<String>> webEV =
                new EventHandler<WebEvent<String>>()
                {
                    @Override
                    public void handle(WebEvent<String> ev)
                    {
                        String data = ev.getData();
                        myAlert = new AlertBox(data);
                        myAlert.initModality(Modality.APPLICATION_MODAL);
                        myAlert.showAndWait();
                    }
                };
        engine.setOnAlert(webEV);

        controls.getChildren().addAll(scriptField, inject);

        this.getChildren().addAll(webTitle,holder, controls);
        engine.load(loadURL);
    }

}
