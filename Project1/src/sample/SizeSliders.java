package sample;

import javafx.event.Event;
import javafx.event.EventHandler;
import javafx.geometry.Insets;
import javafx.scene.control.Label;
import javafx.scene.control.Slider;
import javafx.scene.input.MouseEvent;
import javafx.scene.layout.HBox;

/**
 * Created by alexknipfer on 9/12/15.
 */

//This class contains two sliders in which indicates the rows and columns the user wants in the current
//board.

public class SizeSliders extends HBox
{
    private Slider rowSlider;
    private Slider colSlider;

    public SizeSliders()
    {
            //Sliders that alters rows and columns in grid
        rowSlider = new Slider(4, 20, 10);
        colSlider = new Slider(4, 40, 10);

        Label rowsLabel = new Label("Rows:");
        Label colsLabel = new Label("Columns:");

            //create padding for sliders and labels
        rowSlider.setPadding(new Insets(5, 0, 0, 0));
        rowSlider.setPadding(new Insets(5, 0, 0, 0));
        colSlider.setPadding(new Insets(5, 0, 0, 0));
        colSlider.setPadding(new Insets(5, 0, 0, 0));

        EventHandler<MouseEvent> sliderHandler =
                new EventHandler<MouseEvent>()
                {
                    @Override
                    public void handle(MouseEvent event)
                    {
                            //receiving slider that was accessed
                        Slider touched = (Slider) event.getSource();
                        SizeSliders touchedContainer = (SizeSliders) touched.getParent();
                        Event.fireEvent(touchedContainer, event);
                    }
                };

            //get the slider that was used
        rowSlider.setOnMouseReleased(sliderHandler);
        colSlider.setOnMouseReleased(sliderHandler);

        this.getChildren().addAll(rowsLabel, rowSlider, colsLabel, colSlider);
    }

    //******************************************************************************

        //get the row value from the slider
    public int getRows()
    {
        int currentRows;
        currentRows = (int) rowSlider.getValue();
        return currentRows;
    }

    //******************************************************************************

        //get the column value from the slider
    public int getCols()
    {
        int currentCols;
        currentCols = (int) colSlider.getValue();
        return currentCols;
    }
}
