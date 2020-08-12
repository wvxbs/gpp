using gpp.src.qanda;
using gpp.src.quizactions;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QuizzForms
{
    public partial class Quizz : Form
    {

        static int QuestionIndex = 0;

        static string QuestionsFilePath = @"C:\Users\GabrielFerreira\Documents\repos\gpp\ConsoleQuizz\Questions.txt";

        static RetrieveQandAFromFile RetrieveData = new RetrieveQandAFromFile(QuestionsFilePath);
        static List<string> RawFileData = RetrieveData.GetRawFileData();

        static ProcessQuestions Questions = new ProcessQuestions(RawFileData);
        static ProcessAnswers Answers = new ProcessAnswers(RawFileData);
        static ProcessRightAnswer RightAnswers = new ProcessRightAnswer(RawFileData);
        static Quiz Quiz = new Quiz(Questions, Answers, RightAnswers);

        public Quizz()
        {
            InitializeComponent();
        }

        private void Quizz_Load(object sender, EventArgs e)
        {
            UpdateQuizz();
        }

        private void UpdateQuizz()
        {
            ClearAlteratives();
            UpdateFormTitle();
            RenderAlternatives();
        }

        private void UpdateFormTitle()
        {
            string[] QuestionArray = Quiz.Questions.ToArray();

            title.Text = QuestionArray[QuestionIndex];
        }

        private void RenderAlternatives()
        {
            string [] AnswerList = Quiz.PrintAnswers(QuestionIndex).Split('\n');

            for(int i = 0; i < AnswerList.Length; i++)
            {
                checkedListBox1.Items.Insert(i,AnswerList[i]);
            }
   
        }

        private void ClearAlteratives()
        {
            checkedListBox1.Items.Clear();
        }

        private void AdvanceButtonClick(object sender, EventArgs e)
        {
            if(HasUserInput())
            {
                if (QuestionIndex + 1 < Quiz.Questions.Count)
                {
                    GetUserInput();
                    QuestionIndex = QuestionIndex + 1;
                    UpdateQuizz();
                }
                else
                    EndQuizz();
            }
        }

        private void EndQuizz()
        {
            EndQuizz eq = new EndQuizz();
            eq.Show();
        }


        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int SelectedIndex = checkedListBox1.SelectedIndex;
            if (SelectedIndex == -1)
                return;
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
            checkedListBox1.SetItemCheckState(SelectedIndex, CheckState.Checked);
        }

        private bool HasUserInput()
        {
            if (checkedListBox1.CheckedItems.Count > 0)
                return true;
            else
                return false;
        }

        private void GetUserInput()
        {
            int SelectedIndex = checkedListBox1.SelectedIndex;

            ProcessUserInput(SelectedIndex);
        }

        private void ProcessUserInput(int Selected)
        {
            switch(Selected)
            {
                case 1:
                    Quiz.GetUserInput("a", QuestionIndex);
                break;
                case 2:
                    Quiz.GetUserInput("b", QuestionIndex);
                break;
                case 3:
                    Quiz.GetUserInput("c", QuestionIndex);
                break;
                case 4:
                    Quiz.GetUserInput("d", QuestionIndex);
                break;
                case 5:
                    Quiz.GetUserInput("e", QuestionIndex);
                break;
                default:
                    Quiz.GetUserInput("p", QuestionIndex);
                break;
            }
        }
        
        public string GetQuantityOfQuestions()
        {
            int NumberOfQuestions = Questions.GetQuestions().Count;
            var CorrectAnswers = Quiz.GetCorrectAnswers();

            Percentage Percentage = new Percentage();
            int _Percentage = Percentage.CalculatePercentage(CorrectAnswers, NumberOfQuestions);

            QuizResults QuizResults = new QuizResults(_Percentage, CorrectAnswers.Count, NumberOfQuestions);

            return QuizResults.DisplayNumberOfQuestions();
        }

        public string GetQuantityOfCorrectAnswers()
        {
            int NumberOfQuestions = Questions.GetQuestions().Count;
            var CorrectAnswers = Quiz.GetCorrectAnswers();

            Percentage Percentage = new Percentage();
            int _Percentage = Percentage.CalculatePercentage(CorrectAnswers, NumberOfQuestions);

            QuizResults QuizResults = new QuizResults(_Percentage, CorrectAnswers.Count, NumberOfQuestions);

            return QuizResults.DisplayNumberOfCorrectAnswers();
        }

        public string GetNumberOfErrors()
        {
            int NumberOfQuestions = Questions.GetQuestions().Count;
            var CorrectAnswers = Quiz.GetCorrectAnswers();

            Percentage Percentage = new Percentage();
            int _Percentage = Percentage.CalculatePercentage(CorrectAnswers, NumberOfQuestions);

            QuizResults QuizResults = new QuizResults(_Percentage, CorrectAnswers.Count, NumberOfQuestions);

            return QuizResults.DisplayNumberOfErrors();
        }

        public int GetPercentage()
        {
            int NumberOfQuestions = Questions.GetQuestions().Count;
            var CorrectAnswers = Quiz.GetCorrectAnswers();

            Percentage Percentage = new Percentage();
            int _Percentage = Percentage.CalculatePercentage(CorrectAnswers, NumberOfQuestions);

            QuizResults QuizResults = new QuizResults(_Percentage, CorrectAnswers.Count, NumberOfQuestions);

            return QuizResults.DisplayPercentageAsInt();
        }
    }
}
