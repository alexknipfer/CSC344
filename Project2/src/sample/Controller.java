package sample;

import javafx.event.ActionEvent;
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

    private Scanner read;
    private List<ImageView> myImages;
    private double width;

    @FXML
    private TextField newWidth;

    @FXML
    private FlowPane mainPane;

//********************************************************************************

    @FXML
    void openUp(ActionEvent event) {

        myImages = new ArrayList<ImageView>();

        FileChooser fc = new FileChooser();
        File furl = fc.showOpenDialog(null);

        String url = furl.getPath().replace("\\", "/").replace(" ", "%20");
        String dir = furl.getParent();

        mainPane.setHgap(10);


        try{
            read = new Scanner(new File(url));
        }

        catch(Exception e){
            System.out.println("Could not find file");
        }

        while(read.hasNext())
        {
            String type = read.next();
            String nameOfFile = read.next();
            String title = read.nextLine();


            if(type.equals("image"))
            {
                String imgLink = dir + "/" + nameOfFile;
                Image currentImage = new Image("file:" + imgLink);

                ImageView myImage = new ImageView(currentImage);
                myImage.setFitWidth(150);
                myImage.setPreserveRatio(true);

                myImages.add(myImage);

                VBox imageBox = new VBox();
                Label imgTitle = new Label(title);
                imageBox.getChildren().addAll(imgTitle, myImage);

                myImage.addEventHandler(MouseEvent.MOUSE_ENTERED_TARGET, new EventHandler<MouseEvent>() {

                    @Override
                    public void handle(MouseEvent event) {
                        myImage.setFitWidth(myImage.getFitWidth() * 2);

                    }
                });

                myImage.addEventHandler(MouseEvent.MOUSE_EXITED_TARGET, new EventHandler<MouseEvent>() {

                    @Override
                    public void handle(MouseEvent event) {
                        myImage.setFitWidth(myImage.getFitWidth() / 2);

                    }
                });

                mainPane.getChildren().add(imageBox);
            }

            if(type.equals("media"))
            {
                String mediaLink = dir + "/" + nameOfFile;
                MediaViewBox myMedia = new MediaViewBox(mediaLink, title);
                mainPane.getChildren().add(myMedia);
            }

            if(type.equals("web"))
            {
                WebViewBox webBox = new WebViewBox(nameOfFile);
                mainPane.getChildren().add(webBox);
            }
        }

    }

//********************************************************************************

    @FXML
    void adjustWidth(ActionEvent event) {

        System.out.println(MediaViewBox.myVideos.size());

        width = Double.parseDouble(newWidth.getText());

        for(int x  = 0; x < myImages.size(); x++)
        {
            myImages.get(x).setFitWidth(width);
        }

        for(int y = 0; y < MediaViewBox.myVideos.size(); y++)
        {
            MediaViewBox.myVideos.get(y).setFitWidth(width);
        }
    }

//********************************************************************************

    @FXML
    void showAbout(ActionEvent event) {
        About aboutPrompt = new About();
        aboutPrompt.initModality(Modality.APPLICATION_MODAL);
        aboutPrompt.showAndWait();
    }

//********************************************************************************

    @FXML
    void clearPane(ActionEvent event) {
        mainPane.getChildren().clear();
    }

//********************************************************************************

    @FXML
    void doExit(ActionEvent event) {
        System.exit(0);
    }

}
