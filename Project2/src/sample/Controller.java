package sample;

import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.fxml.FXML;
import javafx.scene.control.Label;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.scene.input.MouseEvent;
import javafx.scene.layout.FlowPane;
import javafx.scene.layout.VBox;
import javafx.stage.FileChooser;

import java.io.File;
import java.util.Scanner;


public class Controller {

    private Scanner read;

    @FXML
    private FlowPane mainPane;

//********************************************************************************

    @FXML
    void openUp(ActionEvent event) {

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


            if(type.equals(type))
            {
                String imgLink = dir + "/" + nameOfFile;
                Image currentImage = new Image("file:" + imgLink);

                ImageView myImage = new ImageView(currentImage);
                myImage.setFitWidth(150);
                myImage.setPreserveRatio(true);

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
                        myImage.setFitWidth(150);

                    }
                });

                mainPane.getChildren().add(imageBox);
            }
        }

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
