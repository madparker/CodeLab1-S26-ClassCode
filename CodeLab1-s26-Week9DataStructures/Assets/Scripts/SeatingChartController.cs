using UnityEngine;
using UnityEngine.UI;

public class SeatingChartController : MonoBehaviour
{
    public int numRows = 5;
    public int numCols = 8;

    private string[,] seatingChart;

    public Text display;
    
    void Start()
    {
        seatingChart = new string[numCols, numRows];

        for (int x = 0; x < seatingChart.GetLength(0); x++)
        {
            for (int y = 0; y < seatingChart.GetLength(1); y++)
            {
                seatingChart[x, y] = "";
            }
        }
        seatingChart[0,0] = "MP";
        seatingChart[1,2] = "AJ";
        seatingChart[2,2] = "GR";
        seatingChart[0,2] = "JR";
        seatingChart[3,2] = "D-";
        seatingChart[2,1] = "MS";
        seatingChart[3,1] = "CL";
        seatingChart[1,1] = "PW";
        seatingChart[0,1] = "MD";
        
        PrintWhereSeated();
    }

    public void PrintWhereSeated()
    {
        string toPrint = "~~~~ FRONT ~~~~\n";
        for (int y = 0; y < seatingChart.GetLength(1); y++)
        {
            for (int x = 0; x < seatingChart.GetLength(0); x++)
            {
                if (seatingChart[x, y] != "")
                {
                    toPrint += seatingChart[x, y];
                }
                else
                {
                    toPrint += " _ ";
                }
            }

            toPrint += "\n";
        }

        toPrint += "~~~~ BACK ~~~~";

        display.text = toPrint;
    }

}
