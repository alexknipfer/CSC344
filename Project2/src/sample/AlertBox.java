package sample;

import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.geometry.Insets;
import javafx.geometry.Pos;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.layout.VBox;
import javafx.stage.Stage;
import javafx.stage.StageStyle;

/**
 * Created by alexknipfer on 10/18/15.
 */
public class AlertBox extends Stage {

    //This class builds a alert box for any javascript alert script injected to
    //web page. It will handle it as a typical javascript alert but prompt in the
    //application instead of the web view

    public AlertBox(String alertData){

            //build label with text from alert input
        Label myData = new Label(alertData);

            //build ok button
        Button ok = new Button("Ok");

            //close alert box after clicking "Ok"
        ok.setOnAction(new EventHandler<ActionEvent>() {
            @Override
            public void handle(ActionEvent event) {
                close();
            }
        });

            //build container for alert box
        VBox root = new VBox();
        root.getChildren().addAll(myData, ok);

            //set padding to stop nodes from pushing against edges of prompt
        root.setPadding(new Insets(10,10,10,10));
        Scene myScene = new Scene(root);
        this.setScene(myScene);

            //remove top bar from window (minimize, close)
        this.initStyle(StageStyle.UNDECORATED);
    }
}
