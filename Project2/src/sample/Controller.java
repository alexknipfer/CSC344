package sample;

import javafx.event.ActionEvent;
import javafx.event.Event;
import javafx.event.EventHandler;
import javafx.fxml.FXML;
import javafx.scene.control.Label;
import javafx.scene.control.TextField;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.scene.input.MouseEvent;
import javafx.scene.layout.FlowPane;
import javafx.scene.layout.VBox;
import javafx.stage.FileChooser;
import javafx.stage.Modality;

import java.io.File;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;


public class Controller {

    private Scanner read;   //the file being read in
    private List<ImageView> myImages;   //holds all images read in from file
    private double width;   //holds current width from text box

    @FXML
    private TextField newWidth; //width text field

    @FXML
    private FlowPane mainPane;  //holds all media, etc.

//********************************************************************************

    @FXML
    void openUp(ActionEvent event) {

            //create array list to hold all images
        myImages = new ArrayList<ImageView>();

        FileChooser fc = new FileChooser();
        File furl = fc.showOpenDialog(null);

            //gets the path of the image
        String url = furl.getPath().replace("\\", "/").replace(" ", "%20");

            //gets the directory in which the image is in
        String dir = furl.getParent();

            //set spacing between all contents added
        mainPane.setHgap(10);

            //attempt to read in file if valid
        try{
            read = new Scanner(new File(url));
        }

            //tell user if file is not good or not selected
        catch(Exception e){
            System.out.println("Could not find file");
        }

            //continue reading file until end of file
        while(read.hasNext())
        {
            String type = read.next();  //holds type of media
            String nameOfFile = read.next();    //holds the name of file
            String title = read.nextLine(); //holds title read in

                //if the media type is image, then add the image
            if(type.equals("image"))
            {
                    //store exact directory of file including the name
                String imgLink = dir + "/" + nameOfFile;

                    //create image based on file path read in
                Image currentImage = new Image("file:" + imgLink);

                    //make the image viewable and set default width of 150
                    //and make the picture have a locked aspect ratio
                ImageView myImage = new ImageView(currentImage);
                myImage.setFitWidth(150);
                myImage.setPreserveRatio(true);

                    //add image to images list so the width can be altered
                    //later for all images (gives a way to access each image)
                myImages.add(myImage);

                    //create the image container with title
                VBox imageBox = new VBox();
                Label imgTitle = new Label(title);
                imageBox.getChildren().addAll(imgTitle, myImage);

                    //the following doubles the viewing width when hovering over with mouse
                myImage.addEventHandler(MouseEvent.MOUSE_ENTERED_TARGET, new EventHandler<MouseEvent>() {

                    @Override
                    public void handle(MouseEvent event) {
                            //make the width twice as big
                        myImage.setFitWidth(myImage.getFitWidth() * 2);

                    }
                });

                    //the following reduces the width back to default when removing mouse off image
                myImage.addEventHandler(MouseEvent.MOUSE_EXITED_TARGET, new EventHandler<MouseEvent>() {

                    @Override
                    public void handle(MouseEvent event) {
                            //divide image width by two to get back to default
                        myImage.setFitWidth(myImage.getFitWidth() / 2);

                    }
                });

                    //add the image "container"
                mainPane.getChildren().add(imageBox);
            }

                //add movie if the type read in is media
            if(type.equals("media"))
            {
                    //get exact path of movie file
                String mediaLink = dir + "/" + nameOfFile;

                    //create new media box and it to pane
                MediaViewBox myMedia = new MediaViewBox(mediaLink, title);
                mainPane.getChildren().add(myMedia);
            }

                //add website if the type read in is web
            if(type.equals("web"))
            {
                    //create new web box (website read in)
                WebViewBox webBox = new WebViewBox(nameOfFile, title);
                mainPane.getChildren().add(webBox);
            }
        }

    }

//********************************************************************************

    @FXML
    void adjustWidth(ActionEvent event) {

        //This method resizes each type of file based on what value is typed
        //in the textbox under "edit"

            //turn text field value into a number
        width = Double.parseDouble(newWidth.getText());

        if(width < 150 || width > 500)
        {
            AlertBox invalidPrompt = new AlertBox("Invalid Input, Pick number between 150 and 500");
            invalidPrompt.initModality(Modality.APPLICATION_MODAL);
            invalidPrompt.showAndWait();
            return;
        }

            //change width of all images
        for(int x  = 0; x < myImages.size(); x++)
        {
            myImages.get(x).setFitWidth(width);
        }

            //change width of all videos
        for(int y = 0; y < MediaViewBox.myVideos.size(); y++)
        {
            MediaViewBox.myVideos.get(y).setFitWidth(width);
        }

            //change width of all web
        for(int z = 0; z < WebViewBox.myWebs.size(); z++)
        {
            WebViewBox.myWebs.get(z).setMinWidth(width);
        }
    }

//********************************************************************************

    @FXML
    void showAbout(ActionEvent event) {

        //This method shows the about prompt with information regarding
        //this program

            //create new prompt
        About aboutPrompt = new About();

            //only allow the user to close prompt before continuing with program
            //i.e can't click anything else outside the prompt
        aboutPrompt.initModality(Modality.APPLICATION_MODAL);
        aboutPrompt.showAndWait();
    }

//********************************************************************************

    @FXML
    void checkContents(Event event){

            //get value of whats in text field
        TextField tf = (TextField) event.getSource();

            //convert text field value to string
        String theyTyped = tf.getText();

        double theirNumber;

            //convert their typed value into number (double)
        try
        {
            theirNumber = Double.parseDouble(theyTyped);
        }

            //if number is invalid keep it at default (150)
        catch(Exception e)
        {
            theirNumber = 150;
        }

            //if number is invalid (less than 150 or greater than 500) show red
        if(theirNumber < 150 || theirNumber > 500)
        {
                //set text color to red
            tf.setStyle("-fx-text-fill: red");
        }

            //if number is within valid range keep it black
        else
        {
                //set text color to black
            tf.setStyle("-fx-text-fill: black");
        }
    }

//********************************************************************************

    @FXML
    void clearPane(ActionEvent event) {

        //This method clears all media outside of the main pane

        mainPane.getChildren().clear();
    }

//********************************************************************************

    @FXML
    void doExit(ActionEvent event) {

        //This method exits (terminates) the program

        System.exit(0);
    }

}
