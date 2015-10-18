package sample;

import javafx.beans.InvalidationListener;
import javafx.beans.Observable;
import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.ProgressBar;
import javafx.scene.input.MouseEvent;
import javafx.scene.layout.HBox;
import javafx.scene.layout.VBox;
import javafx.scene.media.Media;
import javafx.scene.media.MediaPlayer;
import javafx.scene.media.MediaView;
import javafx.util.Duration;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by alexknipfer on 10/15/15.
 */
public class MediaViewBox extends VBox {

    private Media media;
    private MediaPlayer player;
    private MediaView myView;

    private Button play;
    private Button pause;
    private Button reset;

    private ProgressBar progress;

        //keeps all videos in list, initialized here so it doesn't loose content
    public static List<MediaView> myVideos = new ArrayList<MediaView>();

    public MediaViewBox(String fileName, String title) {
            //This constructor calls the method to build the media container
            //receiving the title and the file name

        buildBox(fileName, 150, title);
    }

    private void buildBox(String url, double width, String title) {

            //This method builds the container given the path,
            //width, and the title

            //build label with given title
        Label titleLabel =  new Label(title);

            //create new media from the read in file
        media = new Media("file:" + url);

            //build media player from given file
        player = new MediaPlayer(media);

            //don't play it after being added
        player.setAutoPlay(false);

            //only play one time, don't repeat
        player.setCycleCount(1);

            //build media viewer
        myView = new MediaView();
        myView.setMediaPlayer(player);

            //add media to media list
        myVideos.add(myView);

            //double the size of the video when hovering mouse over
        myView.addEventHandler(MouseEvent.MOUSE_ENTERED_TARGET, new EventHandler<MouseEvent>() {

            @Override
            public void handle(MouseEvent event) {
                    //doubles size of media by multiplying by two
                myView.setFitWidth(myView.getFitWidth() * 2);

            }
        });

            //bring the size of video back to default after moving mouse off of video
        myView.addEventHandler(MouseEvent.MOUSE_EXITED_TARGET, new EventHandler<MouseEvent>() {

            @Override
            public void handle(MouseEvent event) {
                    //bring width back to default by dividing by two
                myView.setFitWidth(myView.getFitWidth() / 2);

            }
        });

            //build progress bar as the same size as video from given width
        progress = new ProgressBar(0);
        progress.setMinWidth(width);

            //build new play button
        play = new Button(">");

            //play video upon clicking button
        play.setOnAction(new EventHandler<ActionEvent>() {
            @Override
            public void handle(ActionEvent event) {
                player.play();
            }
        });

            //bulid new pause button
        pause = new Button("||");

            //pause video upon clicking
        pause.setOnAction(new EventHandler<ActionEvent>() {
            @Override
            public void handle(ActionEvent event) {
                player.pause();
            }
        });

            //build reset button
        reset = new Button("RST");

            //reset video upon clicking button, don't play it automatically
        reset.setOnAction(new EventHandler<ActionEvent>() {
            @Override
            public void handle(ActionEvent event) {
                player.pause();

                    //go back to beginning
                player.seek(new Duration(0));

                    //reset progress bar
                progress.setProgress(0);
            }
        });

            //keeps track of where video is at for progress bar to maintain progress
        player.currentTimeProperty().addListener(
                new InvalidationListener() {
                    @Override
                    public void invalidated(Observable observable) {
                            //set progress bar according to time in video
                        progress.setProgress(player.getCurrentTime().toSeconds() / player.getTotalDuration().toSeconds());
                    }
                }
        );

            //build controls box containing video buttons
        HBox controls = new HBox();
        controls.getChildren().addAll(play, pause, reset);

            //add everything to main container
        this.getChildren().addAll(titleLabel,myView, progress, controls);

            //set width to given width
        myView.setFitWidth(width);

            //maintain aspect ratio
        myView.setPreserveRatio(true);


    }
}
