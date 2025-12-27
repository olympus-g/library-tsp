using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Library.Query_Forms
{
    public partial class ChartsForm : Form
    {
        public ChartsForm()
        {
            InitializeComponent();
        }

        private void ChartsForm_Load(object sender, EventArgs e)
        {
            LoadStatistics();
        }

        private void LoadStatistics()
        {
            int males = 0;
            int females = 0;

            int group1 = 0; // Up to 10
            int group2 = 0; // 10 to 18
            int group3 = 0; // 19 to 30
            int group4 = 0; // 31 to 65
            int group5 = 0; // Over 65

            foreach (var v in GlobalData.AllVisitors)
            {
                if (v.GetGender() == "Male") males++;
                else if (v.GetGender() == "Female") females++;

                int age = v.GetAge();

                if (age < 10) group1++;
                else if (age <= 18) group2++;
                else if (age <= 30) group3++;
                else if (age <= 65) group4++;
                else group5++;
            }

            Title title = new Title();
            title.Text = $"Gender Stats: Males ({males}), Females ({females})";
            title.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            chart.Titles.Clear();
            chart.Titles.Add(title);

            chart.Series.Clear();
            chart.Legends.Clear();

            Series series = new Series("VisitorsByAge");
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;

            series.Points.AddXY("Child (<10)", group1);
            series.Points.AddXY("Student (10-18)", group2);
            series.Points.AddXY("Young Adult (19-30)", group3);
            series.Points.AddXY("Adult (31-65)", group4);
            series.Points.AddXY("Senior (>65)", group5);

            chart.Series.Add(series);

            if (chart.ChartAreas.Count > 0)
            {
                chart.ChartAreas[0].AxisX.Title = "Age Groups";
                chart.ChartAreas[0].AxisY.Title = "Number of Visitors";
                chart.ChartAreas[0].AxisX.Interval = 1;
            }
        }
    }
}
