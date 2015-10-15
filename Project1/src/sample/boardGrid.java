package sample;

import javafx.animation.PathTransition;
import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.geometry.Insets;
import javafx.scene.Node;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.image.ImageView;
import javafx.scene.layout.*;
import javafx.scene.shape.*;
import javafx.stage.Modality;
import javafx.util.Duration;


import java.util.Random;


/**
 * Created by alexknipfer on 9/10/15.
 */

//This class generates a board with buttons based on the current value fo the sliders to indicate
//how large the board needs to be. By default (when the game is opened) it generates a 10x10 board


public class boardGrid extends GridPane
{
    private int rows;
    private int columns;
    private static Button[][] buttons;
    private int currentX;
    private int currentY;
    private GridPane myPane;
    private int usedRows;
    private int usedCols;
    private WinPrompt winner;
    private BetterMove moveBetter;
    private Node lbl;

    public boardGrid(int currentRows, int currentCols)
    {
            //  This constructor takes in values of the current values
            //  in the rows slider and columns slider. It then builds
            // the board based on those sizes

        buttons = new Button[20][40];   //builds array for maximum number of button (grid size)
        usedRows = currentRows;     //store current rows from slider value
        usedCols = currentCols;     //store current columns from slider value
        myPane = this;
        
            //build the array of buttons based on size passed in from sliders
        for(rows = 0; rows < currentRows; rows++)
        {
            for(columns = 0; columns < currentCols; columns++)
            {
                buttons[rows][columns] = new Button();

                    //set button sizes to 30 x 30
                buttons[rows][columns].setMinWidth(30.0);
                buttons[rows][columns].setMinHeight(30.0);
                this.setConstraints(buttons[rows][columns], columns, rows);

                buttons[rows][columns].setOnAction(new EventHandler<ActionEvent>()
                {
                    @Override
                    public void handle(ActionEvent event)
                    {
                            //Get the exact button clicked
                        Object source = event.getSource();
                        Button clickedBtn = (Button) source;

                            //don't allow player to click a computer move
                        if(clickedBtn.getText() == "Y")
                        {
                                //show prompt telling user illegal move
                            moveBetter = new BetterMove();
                            moveBetter.initModality(Modality.APPLICATION_MODAL);
                            moveBetter.showAndWait();
                        }
                            //Allow player to only play non played buttons
                        else if(clickedBtn.getText() == "" && clickedBtn.getText() != "Y")
                        {
                                //add image to button if user has selected an image
                            if(AddDialog.getxImage() == true)
                            {
                                clickedBtn.setText(null);
                                clickedBtn.setPadding(Insets.EMPTY);
                                clickedBtn.setGraphic(new ImageView(AddDialog.getXImage()));
                                clickedBtn.setId("xHasImage");
                            }

                                //add default x if no image has been selected
                            else
                            {
                                clickedBtn.setText("X");
                            }
                            playComputer(usedRows, usedCols);
                        }
                            //get the location in grid where the button clicked is located
                        currentX = myPane.getRowIndex(clickedBtn);
                        currentY = myPane.getColumnIndex(clickedBtn);
                        checkWin(usedRows, usedCols);
                    }
                });
                    //add buttons to the board
                this.getChildren().add(buttons[rows][columns]);
            }
        }
    }

    //******************************************************************************

        //returns the current amount of buttons in the array for the current size board
    public static Button[][] getButtons()
    {
        return (buttons);
    }

    //******************************************************************************


    public void playComputer(int usedRows, int usedCols)
    {
            //Given - current rows from slider value, current cols from slider value
            //Task - generate random moves for board size based on slider values
            //Returns - nothing

            //Create random moves for new board size based on slider values
        Random random = new Random();
        int rndRows = random.nextInt(usedRows);
        int rndCols = random.nextInt(usedCols);

            //keep generating random moves until move is legal
        while(true)
        {
                //make sure the number generated isn't a move on the board that has already been played
                //I.E - make sure it doesn't place a "Y" on top of another Y or X
            if(buttons[rndRows][rndCols].getText() != "X" && buttons[rndRows][rndCols].getText() != "Y" &&
                    buttons[rndRows][rndCols].getId() != "xHasImage" && buttons[rndRows][rndCols].getId() != "yHasImage")
            {
                    //get the location of the random generated move
                int xLoc = (int)buttons[rndRows][rndCols].getLayoutX();
                int yLoc = (int) buttons[rndRows][rndCols].getLayoutY();

                    //start animation to simulate computer move
                startAnim(xLoc + 15, yLoc + 8, rndRows, rndCols);
                break;
            }

                //do this if the move generated above was not legal, (generate new coordinates)
            else
            {
                    //generate new moves
                rndRows = random.nextInt(usedRows);
                rndCols = random.nextInt(usedCols);
            }

        }
    }


    //******************************************************************************

    private void startAnim(int x, int y, int rndRows, int rndCols)
    {
            //Given - locations (x and y) of ending location of path, and the randomly generated rows and columns
            //        coordinates of the computers move
            //Task - animate the computers move of a "Y" moving Y
            //Returns - nothing

            //build new path
        Path path = new Path();

            //build path transition
        PathTransition myPath = new PathTransition();

            //get x location of button
        Button player2Button = Main.getPlayer2();
        double xLocation = player2Button.getLayoutX();

            //generate starting point of the path
        path.getElements().add(new MoveTo(xLocation + 40, Main.getButtonPosition() - 20));

            //generate ending point of the path
        path.getElements().add(new LineTo(x, y));


            //if user has a image selected for player 2, use it to animate
        if(AddDialog.getyImage() == true)
        {
                //set the label node to current image for player 2 (computer)
            lbl = new ImageView(AddDialog.getYImage());
        }

            //if user has not selected an image for player 2, use "Y" to animate
        else
        {
                //make the node "label" in order to make it move
            lbl = new Label("Y");
        }

            //add label to scene
        this.getChildren().add(lbl);

            //make the path last 5 seconds then play the animation
        myPath.setDuration(Duration.seconds(0.5));
        myPath.setPath(path);
        myPath.setNode(lbl);
        myPath.play();

            //after the path is completed then remove the label and apply the text
            //to the button it moved to
        myPath.setOnFinished(new EventHandler<ActionEvent>(){
            @Override
            public void handle(ActionEvent arg0) {
                myPane.getChildren().remove(lbl);

                if(AddDialog.getyImage() == true)
                {
                    buttons[rndRows][rndCols].setText(null);
                    buttons[rndRows][rndCols].setPadding(Insets.EMPTY);
                    buttons[rndRows][rndCols].setGraphic(new ImageView(AddDialog.getYImage()));
                    buttons[rndRows][rndCols].setId("yHasImage");
                }

                else
                    buttons[rndRows][rndCols].setText("Y");
            }
        });
    }

    //******************************************************************************************

    public void checkWin(int usedRows, int usedCols)
    {
            //Given - current rows and columns from slider values
            //Task - check for four in a row in board size based on slider values
            //Returns - nothing

            //The following checks for wins vertically in the positive direction
            //and then prompts a dialog saying the game has been won
        
        if(currentX <= usedRows - 4 && buttons[currentX+1][currentY].getText()=="X" && buttons[currentX+2][currentY].getText()=="X"
                && buttons[currentX+3][currentY].getText()=="X" || currentX<=usedRows-4 && buttons[currentX+1][currentY].getId()=="xHasImage"
                && buttons[currentX+2][currentY].getId()=="xHasImage" && buttons[currentX+3][currentY].getId()=="xHasImage") // 4 in a row vertically
        {
                //prompt the win dialog
            winner = new WinPrompt();
            winner.initModality(Modality.APPLICATION_MODAL);
            winner.showAndWait();
        }

            //The following checks for wins vertically in the negative direction
            //and then prompts a dialog saying the game has been won
        else if(currentX <= usedRows && currentX >= 3 && buttons[currentX-1][currentY].getText()=="X" &&
                buttons[currentX-2][currentY].getText()=="X" && buttons[currentX-3][currentY].getText()=="X" || currentX <= usedRows &&
                currentX >=3 && buttons[currentX-1][currentY].getId()=="xHasImage" && buttons[currentX-2][currentY].getId()=="xHasImage"
                && buttons[currentX-3][currentY].getId()=="xHasImage")
        {
                //prompt the win dialog
            winner = new WinPrompt();
            winner.initModality(Modality.APPLICATION_MODAL);
            winner.showAndWait();
        }

            //if now wins have been found in the vertical direction, check horizontally
        else
        {
                //The following checks for wins horizontally in the positive direction
                //and then prompts a dialog saying the game has been won
            if(currentY<=usedCols-3 && buttons[currentX][currentY+1].getText()=="X" && buttons[currentX][currentY+2].getText()=="X"
                    && buttons[currentX][currentY+3].getText()=="X" || currentY<=usedCols-3 && buttons[currentX][currentY+1].getId()=="xHasImage"
                    && buttons[currentX][currentY+2].getId()=="xHasImage" && buttons[currentX][currentY+3].getId()=="xHasImage") // 4 in a row vertically
            {
                    //prompt the win dialog
                winner = new WinPrompt();
                winner.initModality(Modality.APPLICATION_MODAL);
                winner.showAndWait();
            }

                //The following checks for wins horizontally in the negative direction
                //and then prompts a dialog saying the game has been won
            else if(currentY <= usedCols && currentY >= 3 && buttons[currentX][currentY-1].getText()=="X" &&
                    buttons[currentX][currentY-2].getText()=="X" && buttons[currentX][currentY-3].getText()=="X" ||
                    currentY <= usedCols && currentY >=3 && buttons[currentX][currentY-1].getId()=="xHasImage" &&
                            buttons[currentX][currentY-2].getId()=="xHasImage" && buttons[currentX][currentY-3].getId()=="xHasImage")
            {
                    //prompt the win dialog
                winner = new WinPrompt();
                winner.initModality(Modality.APPLICATION_MODAL);
                winner.showAndWait();
            }
        }

        //************ Check Computer Wins *********************

        if(currentX <= usedRows - 4 && buttons[currentX+1][currentY].getText()=="Y" && buttons[currentX+2][currentY].getText()=="Y"
                && buttons[currentX+3][currentY].getText()=="Y" || currentX<=usedRows-4 && buttons[currentX+1][currentY].getId()=="yHasImage"
                && buttons[currentX+2][currentY].getId()=="yHasImage" && buttons[currentX+3][currentY].getId()=="yHasImage") // 4 in a row vertically
        {
            //prompt the win dialog
            winner = new WinPrompt();
            winner.initModality(Modality.APPLICATION_MODAL);
            winner.showAndWait();
        }

        //The following checks for wins vertically in the negative direction
        //and then prompts a dialog saying the game has been won
        else if(currentX <= usedRows && currentX >= 3 && buttons[currentX-1][currentY].getText()=="Y" &&
                buttons[currentX-2][currentY].getText()=="Y" && buttons[currentX-3][currentY].getText()=="Y" || currentX <= usedRows &&
                currentX >=3 && buttons[currentX-1][currentY].getId()=="yHasImage" && buttons[currentX-2][currentY].getId()=="yHasImage"
                && buttons[currentX-3][currentY].getId()=="yHasImage")
        {
            //prompt the win dialog
            winner = new WinPrompt();
            winner.initModality(Modality.APPLICATION_MODAL);
            winner.showAndWait();
        }

        //if now wins have been found in the vertical direction, check horizontally
        else
        {
            //The following checks for wins horizontally in the positive direction
            //and then prompts a dialog saying the game has been won
            if(currentY<=usedCols-3 && buttons[currentX][currentY+1].getText()=="Y" && buttons[currentX][currentY+2].getText()=="Y"
                    && buttons[currentX][currentY+3].getText()=="Y" || currentY<=usedCols-3 && buttons[currentX][currentY+1].getId()=="yHasImage"
                    && buttons[currentX][currentY+2].getId()=="yHasImage" && buttons[currentX][currentY+3].getId()=="yHasImage") // 4 in a row vertically
            {
                //prompt the win dialog
                winner = new WinPrompt();
                winner.initModality(Modality.APPLICATION_MODAL);
                winner.showAndWait();
            }

            //The following checks for wins horizontally in the negative direction
            //and then prompts a dialog saying the game has been won
            else if(currentY <= usedCols && currentY >= 3 && buttons[currentX][currentY-1].getText()=="Y" &&
                    buttons[currentX][currentY-2].getText()=="Y" && buttons[currentX][currentY-3].getText()=="Y" ||
                    currentY <= usedCols && currentY >=3 && buttons[currentX][currentY-1].getId()=="yHasImage" &&
                            buttons[currentX][currentY-2].getId()=="yHasImage" && buttons[currentX][currentY-3].getId()=="yHasImage")
            {
                //prompt the win dialog
                winner = new WinPrompt();
                winner.initModality(Modality.APPLICATION_MODAL);
                winner.showAndWait();
            }
        }
    }
}
