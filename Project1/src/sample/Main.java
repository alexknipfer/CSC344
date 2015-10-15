package sample;

import javafx.application.Application;
import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.geometry.Insets;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.input.MouseEvent;
import javafx.scene.layout.HBox;
import javafx.scene.layout.VBox;
import javafx.stage.Modality;
import javafx.stage.Stage;

public class Main extends Application {

    private SizeSliders sliderValues;
    private boardGrid mainBoard;
    private boardGrid newGrid;
    private static HBox lowerPanel;
    private HBox newButton;
    private static int currentRows;
    private static int currentCols;
    private static Button player1;
    private static Button player2;

    @Override
    public void start(Stage primaryStage) throws Exception
    {
            //Main layout for top panel, grid, and lower panel
        VBox root = new VBox();

            //Contains player 1 and player 2 buttons
        lowerPanel = new HBox();

            //Contains new game button and and sliders
        newButton = new HBox();
        Button newGame = new Button("New Game");

        sliderValues = new SizeSliders();
        newButton.getChildren().addAll(newGame, sliderValues);

            //initialize default board size to 10x10
        currentRows = 10;
        currentCols = 10;

            //Gets current rows and columns based on slider positions
        sliderValues.setOnMouseReleased(new EventHandler<MouseEvent>() {
            @Override
            public void handle(MouseEvent event) {
                currentRows = sliderValues.getRows();
                currentCols = sliderValues.getCols();
            }
        });

        //Build instance of the default board (grid)
        mainBoard = new boardGrid(currentRows, currentCols);

            //Removes grid and buttons and replaces with new grid with new sized grid based on sliders
            //Note - lower panel is removed so when grid is replaces the buttons remain below the grid
        newGame.setOnAction(new EventHandler<ActionEvent>() {
            @Override
            public void handle(ActionEvent event) {
                    //erase board and add new board
                root.getChildren().removeAll(newGrid, lowerPanel);

                    //create new board based on slider values
                newGrid = new boardGrid(currentRows, currentCols);
                root.getChildren().removeAll(mainBoard,lowerPanel);
                root.getChildren().addAll(newGrid, lowerPanel);

                    //reset buttons to default in case user has changed to image
                player1.setPadding(new Insets(5,5,5,5));
                player1.setGraphic(null);
                player1.setText("Player 1: X");
                player2.setPadding(new Insets(5, 5, 5, 5));
                player2.setGraphic(null);
                player2.setText("Player 2: Y");
            }
        });

        //********** Lower Panel ************/
        player1 = new Button("Player 1: X");
        player2 = new Button("Player 2: Y");
        player1.setPadding(new Insets(5, 5, 5, 5));
        player2.setPadding(new Insets(5, 5, 5, 5));

            //Prompt user once player 1 is selected
        player1.setOnAction(new EventHandler<ActionEvent>() {
            @Override
            public void handle(ActionEvent event) {
                AddDialog adder = new AddDialog("X");
                adder.initModality(Modality.APPLICATION_MODAL);
                adder.showAndWait();
            }
        });

            //prompt user if player2 button is clicked
        player2.setOnAction(new EventHandler<ActionEvent>() {
            @Override
            public void handle(ActionEvent event) {
                AddDialog player2Adder = new AddDialog("Y");
                player2Adder.initModality(Modality.APPLICATION_MODAL);
                player2Adder.showAndWait();
            }
        });

        lowerPanel.getChildren().addAll(player1, player2);
        //************************************


            //Add everything to default "root"
        root.getChildren().addAll(newButton, mainBoard, lowerPanel);

        Scene scene = new Scene(root, 500, 500);

        primaryStage.setTitle("Four in a Row");
        primaryStage.setScene(scene);
        primaryStage.show();
    }

        //gets lower panel y position in order to get button position for animation starting point
    public static double getButtonPosition()
    {
        return lowerPanel.getLayoutY();
    }

        //gets the current player1 button
    public static Button getPlayer1()
    {
            //allows other classes to alter player1 button
        return player1;
    }

        //gets the current player2 button
    public static Button getPlayer2()
    {
            //allows other classes to alter player2 button
        return player2;
    }

        //gets the current amount of rows based on slider value
    public static int getRows()
    {
            //allows other classes to get the current value of rows of board
        return currentRows;
    }

        //gets the current amount of columns based on slider value
    public static int getCols()
    {
            //allows other classes to get the current value of columns of board
        return currentCols;
    }

    public static void main(String[] args)
    {
        launch(args);
    }
}
