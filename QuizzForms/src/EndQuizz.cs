using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizzForms
{
    public partial class EndQuizz : Form
    {
        Quizz Quizz = new Quizz();

        public EndQuizz()
        {
            InitializeComponent();
        }

        private void EndQuizz_Load(object sender, EventArgs e)
        {
            UpdateStatus();
        }

        private bool HasWon ()
        {
            if(Convert.ToDouble(Quizz.GetPercentage()) > 74)
                return true;
            else
                return false;
        }

        private void UpdateStatus()
        {
            if (HasWon())
                UpdateTitle("Venceu!");
            else
                UpdateTitle("Perdeu!");

            UpdateQtdOfQuestions(Quizz.GetQuantityOfQuestions());
            UpdateQtdOfCorrectAlternatives(Quizz.GetQuantityOfCorrectAnswers());
            UpdateQtdOfErrors(Quizz.GetNumberOfErrors());
            UpdatePercentage(Quizz.GetPercentage().ToString());
        }

        private void UpdateTitle(string str)
        {
            title.Text = str;
        }

        private void UpdateQtdOfQuestions(string str)
        {
            lbl1.Text = str;
        }

        private void UpdateQtdOfCorrectAlternatives(string str)
        {
            lbl2.Text = str;
        }

        private void UpdateQtdOfErrors(string str)
        {
            lbl3.Text = str;
        }

        private void UpdatePercentage(string str)
        {
            lbl4.Text = $"Porcentagem de acerto: {str}%";
        }

        private void lbl1_Click(object sender, EventArgs e)
        {

        }

        private void lbl4_Click(object sender, EventArgs e)
        {

        }
    }
}
