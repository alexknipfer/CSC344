package sample;

import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.geometry.Insets;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.layout.VBox;
import javafx.stage.Stage;

/**
 * Created by alexknipfer on 9/16/15.
 */

//This class generates a prompt if the user trys to make a move in which has already been played.
//In other words, if their is a "X" or a "Y" in a button and the user trys to play it, this prompt
//will show. Contains a label and a "OK" button

public class BetterMove extends Stage
{
        //construct window that tells user it was a bad move, already been played
    public BetterMove()
    {
            //build label to display
        Label playBetter = new Label("Don't cheat! Play a better move, I already played here!");

            //build ok button
        Button ok = new Button("Ok");

            //close window when ok is clicked
        ok.setOnAction(new EventHandler<ActionEvent>() {
            @Override
            public void handle(ActionEvent event) {
                close();
            }
        });

        VBox root = new VBox();
        root.setPadding(new Insets(30, 30, 30, 30));
        root.getChildren().addAll(playBetter, ok);
        Scene s = new Scene(root);
        this.setScene(s);
    }
}
