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
    public AlertBox(String alertData){

        Label myData = new Label(alertData);

        Button ok = new Button("Ok");

        ok.setOnAction(new EventHandler<ActionEvent>() {
            @Override
            public void handle(ActionEvent event) {
                close();
            }
        });


        VBox root = new VBox();
        root.getChildren().addAll(myData, ok);
        root.setPadding(new Insets(10,10,10,10));
        Scene myScene = new Scene(root);
        this.setScene(myScene);
        this.initStyle(StageStyle.UNDECORATED);
    }
}
