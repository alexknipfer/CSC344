package sample;

import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.geometry.Insets;
import javafx.scene.Node;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.ContentDisplay;
import javafx.scene.control.RadioButton;
import javafx.scene.control.ToggleGroup;
import javafx.scene.image.ImageView;
import javafx.scene.layout.*;
import javafx.stage.FileChooser;
import javafx.stage.Stage;
import javafx.scene.image.Image;


import java.awt.*;
import java.io.File;

/**
 * Created by alexknipfer on 9/14/15.
 */

//This class is the dialog box that pops up when a player clicks player 1 or player 2
//buttons. It contains two radio buttons, one to choose an image for their player token
//and another to change their tokens back to the defaults (x and y). It also contains an "ok" and
//"cancel" button for the user to select to accept their changes or cancel out of this prompt

public class AddDialog extends Stage
{
        //images for player 1 and player 2 (computer)
    private static Image xMyImage;
    private static Image yMyImage;

        //only reason initialized in declaration is so if you get the values from another class before
        //the constructor is ran, we have values
    private static Boolean xImage = false;
    private static Boolean yImage = false;

    public AddDialog(String player)
    {
            //group to hold the radio buttons
        ToggleGroup options = new ToggleGroup();

            //build the letter radio button
        RadioButton letter = new RadioButton(player);
        letter.setToggleGroup(options);

            //build the image radio button
        RadioButton image = new RadioButton("Choose Image");
        image.setToggleGroup(options);

            //choose letter button by default
        options.selectToggle(letter);

            //controls holds ok and cancel button
        HBox controls = new HBox();
            //set padding to prevent everything bumping against edges
        controls.setPadding(new Insets(10,10,10,10));
        controls.setSpacing(10);

            //builds ok and cancel buttons in the dialog box
        Button cancel = new Button("Cancel");
        Button ok = new Button("Accept");

            //add ok and cancel buttons to controls
        controls.getChildren().addAll(cancel,ok);


            //do the following when the ok button is selected
        ok.setOnAction(new EventHandler<ActionEvent>() {
            @Override
            public void handle(ActionEvent event)
            {
                    //used to compare what radio button is selected
                String image = "Choose Image";
                    //get the selected radio button
                RadioButton chk = (RadioButton) options.getSelectedToggle();

                    //get the current array of buttons from main
                Button[][] myButtons = boardGrid.getButtons();

                    //get player buttons from main
                Button player1 = Main.getPlayer1();
                Button player2 = Main.getPlayer2();

                ImageView myPictureX;   //image for player 1
                ImageView myPictureY;   //image for player 2

                    //add the image to nodes so they can be applied has a graphic to a button
                Node pictureX = null;
                Node pictureY = null;

                    //see if the selected radio button equals the image button
                if(image.equals(chk.getText()))
                {
                        //allow user to choose a file from computer
                    FileChooser fileChooser = new FileChooser();
                    File file = fileChooser.showOpenDialog(null);

                        //if player 1 is selected add the selected picture
                    if(player == "X")
                    {
                            //store as image
                        xMyImage = new Image(file.toURI().toString(), 25, 25, false, false);

                            //make the image viewable
                        myPictureX = new ImageView(xMyImage);

                            //create a node out of image for button graphic
                        pictureX = myPictureX;
                    }

                        //if player 2 is selected add the selected picture
                    if(player == "Y")
                    {
                            //store as image
                        yMyImage = new Image(file.toURI().toString(), 25, 25, false, false);

                            //make the image viewable
                        myPictureY = new ImageView(yMyImage);

                            //create a node out of image for button graphic
                        pictureY = myPictureY;
                    }

                        //check to see what player button is selected
                    if(player == "X")
                    {
                            //go through current button array
                        for(int x = 0; x < Main.getRows(); x++)
                        {
                            for (int y = 0; y < Main.getCols(); y++)
                            {
                                    //this finds all "X" on board right now to replace with chosen image
                                if(myButtons[x][y].getText() == "X" || myButtons[x][y].getId() == "xHasImage")
                                {
                                        //clear the button (the X)
                                    myButtons[x][y].setText(null);
                                    myButtons[x][y].setPadding(Insets.EMPTY);

                                        //set the image to the current button
                                    myButtons[x][y].setGraphic(new ImageView(xMyImage));

                                        //reset the player1 button to display the image
                                    player1.setText("Player 1:");
                                    player1.setGraphic(pictureX);
                                    player1.setPadding(new Insets(0,0,0,0));
                                    player1.setContentDisplay(ContentDisplay.RIGHT);

                                        //set ID so it can be changed back to character
                                    myButtons[x][y].setId("xHasImage");

                                        //change to true because image is now in button
                                    xImage = true;
                                }
                            }
                        }
                    }

                        //the computer button (player 2) is selected
                    else
                    {
                            //go through current array of buttons
                        for(int x = 0; x < Main.getRows(); x++)
                        {
                            for (int y = 0; y < Main.getCols(); y++)
                            {
                                    //find all "Y"s on the board to be replaced by image
                                if(myButtons[x][y].getText() == "Y" || myButtons[x][y].getId() == "yHasImage")
                                {
                                        //clear the button (the Y)
                                    myButtons[x][y].setText(null);
                                    myButtons[x][y].setPadding(Insets.EMPTY);

                                        //set the image to current button
                                    myButtons[x][y].setGraphic(new ImageView(yMyImage));

                                       //reset the player2 button to display image
                                    player2.setText("Player 2:");
                                    player2.setGraphic(pictureY);
                                    player2.setPadding(new Insets(0,0,0,0));
                                    player2.setContentDisplay(ContentDisplay.RIGHT);

                                        //set ID so button can be changed back to character
                                    myButtons[x][y].setId("yHasImage");

                                        //change to true because image is now in button
                                    yImage = true;
                                }
                            }
                        }
                    }
                        //close dialog
                    close();
                }

                    //Other radio button is checked (character x or y)
                else
                {
                        //check to see if button clicked is "player1" button
                    if(player == "X")
                    {
                            //go through current array of buttons
                        for(int x = 0; x < Main.getRows(); x++)
                        {
                            for (int y = 0; y < Main.getCols(); y++)
                            {
                                    //find all buttons where X's were changed to an image
                                    //The following changes all buttons back to Y's from image
                                    //if user selects X's to be used as their token again
                                if(myButtons[x][y].getId() == "xHasImage")
                                {
                                        //set the text back to x
                                    myButtons[x][y].setText("X");

                                        //remove the graphic
                                    myButtons[x][y].setGraphic(null);

                                        //remove the ID
                                    myButtons[x][y].setId("");

                                        //reset the player 1 button back to default
                                    player1.setGraphic(null);
                                    player1.setText(null);
                                    player1.setText("Player 1: X");
                                    player1.setPadding(new Insets(5,5,5,5));

                                    xImage = false;
                                }
                            }
                        }
                    }

                        //button clicked is player2
                    else
                    {
                            //go through current array of buttons
                        for(int x = 0; x < Main.getRows(); x++)
                        {
                            for (int y = 0; y < Main.getCols(); y++)
                            {
                                    //find all buttons where Y's were changed to an image
                                    //The following changes all buttons back to Y's from image
                                    //if user selects Y's to be used as their token again
                                if(myButtons[x][y].getId() == "yHasImage")
                                {
                                        //set text of button back to Y
                                    myButtons[x][y].setText("Y");
                                    myButtons[x][y].setGraphic(null);
                                    myButtons[x][y].setId("");

                                        //reset player 2 button back to default by removing graphic and
                                        //resetting text
                                    player2.setGraphic(null);
                                    player2.setText(null);
                                    player2.setText("Player 2: Y");
                                    player2.setPadding(new Insets(5,5,5,5));

                                    yImage = false;
                                }
                            }
                        }
                    }
                        //close dialog
                    close();
                }
            }
        });

            //if cancel is clicked just close the dialog
        cancel.setOnAction(new EventHandler<ActionEvent>() {
            @Override
            public void handle(ActionEvent event)
            {
                close();
            }
        });

        VBox root = new VBox();
        root.setPadding(new Insets(10,10,10,10));
        root.getChildren().addAll(letter, image, controls);
        Scene s = new Scene(root);
        this.setScene(s);
    }

        //returns if an image exists for player 1 (if they have selected an image)
    public static Boolean getxImage()
    {
        return xImage;
    }

        //returns if an image exists for player 2 (if they have selected an image)
    public static Boolean getyImage()
    {
        return yImage;
    }

        //returns the current image selected for player 1
    public static Image getXImage()
    {
        return xMyImage;
    }

        //returns the current image selected for player 2
    public static Image getYImage()
    {
        return yMyImage;
    }

}
