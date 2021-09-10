using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using Newtonsoft.Json;

namespace UltimatePredictor
{
  public partial class Form1 : Form
  {
    private const string APP_NAME = "ULTIMATE_PREDICTOR";
    private readonly string PREDICTIONS_CONFIG_PATH = $"{Environment.CurrentDirectory}\\predictionsConfig.json";
    private string[] _predictions;
    public Form1()
    {
      InitializeComponent();
    }

    private async void bPredict1_Click(object sender, EventArgs e)
    {
      bPredict1.Enabled = false;
      await Task.Run(() =>
      {
        for (int i = 0; i < 100; i++)
        {
          Invoke(new Action(() =>
          {
            updateProgressBar(i);
            this.Text = $"{i + 1}%";

          }));

          Thread.Sleep(50);
        }
      });

      MessageBox.Show("Ты пидор.");
      progressBar1.Value = 0;
      this.Text = APP_NAME;
      bPredict1.Enabled = true;

    }

    private void updateProgressBar(int i)
    {
      if (i == progressBar1.Maximum)
      {
        progressBar1.Maximum = i + 1;
        progressBar1.Value = i + 1;
        progressBar1.Maximum = i;

      }
      else
      {
        progressBar1.Value = i + 1;
      }

      progressBar1.Value = i;
    }

    private void progressBar1_Click(object sender, EventArgs e)
    {

    }

    private void Form1_Load(object sender, EventArgs e)
    {
      this.Text = APP_NAME;
      try
      {
        var data = File.ReadAllText(PREDICTIONS_CONFIG_PATH, Encoding.GetEncoding("windows-1251"));
        _predictions = JsonConvert.DeserializeObject<string[]>(data); 
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
        throw;
      }
      finally
      {

      }

    }
  }
}
