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

//This class prompts a user that the game is over once 4 tokens are in a row

public class WinPrompt extends Stage
{
        //initialize the winner prompt
    public WinPrompt()
    {
            //Create a label to display text
        Label youWin = new Label("Winner, Game Over!");

            //build ok button
        Button ok = new Button("Ok");

            //once ok is clicked just close the prompt
        ok.setOnAction(new EventHandler<ActionEvent>() {
            @Override
            public void handle(ActionEvent event) {
                close();
            }
        });

            //generate scene
        VBox root = new VBox();
        root.setPadding(new Insets(30, 30, 30, 30));
        root.getChildren().addAll(youWin, ok);
        Scene s = new Scene(root);
        this.setScene(s);
    }
}
