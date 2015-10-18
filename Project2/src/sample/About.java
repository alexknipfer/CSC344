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
 * Created by alexknipfer on 10/15/15.
 */
public class About extends Stage {

        //This class builds a About Box giving information about the program
        //including the build date, the title, and the developer

    public About(){

            //build label for project name
        Label projectName = new Label("MediaViewer (Project 2)");

            //build label for name of developer
        Label name = new Label("Alex Knipfer");

            //build label for the build date of the program
        Label buildDate = new Label("October 2015");

            //build ok button
        Button ok = new Button("Ok");

            //close the about box after clicking "Ok"
        ok.setOnAction(new EventHandler<ActionEvent>() {
            @Override
            public void handle(ActionEvent event) {
                close();
            }
        });


            //build container for prompt
        VBox root = new VBox();
        root.getChildren().addAll(projectName, name, buildDate, ok);

            //center everything in prompt
        root.setAlignment(Pos.CENTER);

            //add padding so nodes aren't pushed up against edges of prompt
        root.setPadding(new Insets(10,10,10,10));
        Scene myScene = new Scene(root);
        this.setScene(myScene);

            //remove window top bar (minimize, close)
        this.initStyle(StageStyle.UNDECORATED);
    }

}
