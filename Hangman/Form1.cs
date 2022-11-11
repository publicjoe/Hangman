using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Publicjoe.Windows;

namespace Hangman
{
  public partial class Form1 : Form
  {
    private Man TheMan;
    private LetterManager TheLetterManager;
    private RandomWordManager TheWordManager;
    private WinLoseManager TheWinLoseManager;
    private int Score = 0;

    private HighScoreTable highScoreTable = new HighScoreTable();

    public Form1()
    {
      InitializeComponent();

      TheMan = new Man();
      TheMan.SetPosition(20, 140);
      TheWordManager = new RandomWordManager();
      TheLetterManager = new LetterManager(TheWordManager.Pick());
      TheLetterManager.SetPosition(20, 150);
      TheLetterManager.SetMissPosition(this.ClientRectangle.Right - 200, this.ClientRectangle.Bottom - 40);
      TheWinLoseManager = new WinLoseManager();

      // Load high score table...
      highScoreTable.Load(Application.StartupPath + @"\score.txt");
    }

    protected override void OnKeyPress(KeyPressEventArgs e)
    {
      // Capture Enter key to stop score bug
      if (e.KeyChar == (char)13)
        return;

      char ch = e.KeyChar;

      // Only allow letters ofthe alphabet
      String str = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
      if( str.Contains((Char.ToUpper(ch)).ToString()) == false )
      {
        return;
      }      

      if (TheLetterManager.GotALetter(Char.ToUpper(ch)) == 0)
      {
        //Check that the letter is not already in the missing list
        TheMan.NumberOfMisses++;
      }

      if (TheWinLoseManager.CheckForLoss(TheMan.NumberOfMisses))
      {
        TheWinLoseManager.YouLoseFlag = true;
      }

      if (TheWinLoseManager.CheckForWin(TheLetterManager.GetNumberOfGuesses(),
                                        TheLetterManager.GetHiddenWord()))
      {
        if (TheWinLoseManager.YouWinFlag == false)
        {
          TheWinLoseManager.YouWinFlag = true;
          Score += 10;
        }
      }

      this.Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      Graphics g = e.Graphics;

      TheMan.DrawHangMan(g);
      TheWordManager.drawCategory(g);
      TheLetterManager.DrawLetters(g);
      g.DrawString("Score : " + Score.ToString(), new Font("Arial", 10), new SolidBrush(Color.Blue), 200, 50);
      g.DrawString("Missed Letters : ",
                   new Font("Arial", 12),
                   new SolidBrush(Color.Blue),
                   this.ClientRectangle.Right - 320,
                   this.ClientRectangle.Bottom - 40);

      if (TheWinLoseManager.YouLoseFlag == true)
      {
        TheWinLoseManager.YouLose(g);
        this.button1.Visible = true;
        TheLetterManager.drawHiddenWord(g);
      }
      else if (TheWinLoseManager.YouWinFlag == true)
      {
        TheWinLoseManager.YouWin(g);
        this.button1.Visible = true;
      }
    }

    private void highScoresToolStripMenuItem_Click(object sender, EventArgs e)
    {
      HighScoreForm HighScoreForm = new HighScoreForm(highScoreTable);
      HighScoreForm.StartPosition = FormStartPosition.CenterScreen;
      HighScoreForm.Show();
    }

    private void rulesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      (new RulesForm()).ShowDialog();
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void CheckHighScore()
    {
      highScoreTable.Load(Application.StartupPath + @"\score.txt");

      int scoreIndex = highScoreTable.GetIndexOfScore(Score);

      if (scoreIndex > -1)
      {
        string name = "";
        using (EntryForm aForm = new EntryForm())
        {
          aForm.StartPosition = FormStartPosition.CenterScreen;

          if (aForm.ShowDialog() == DialogResult.OK)
          {
            name = aForm.textBox1.Text;

            highScoreTable.Update(name, Score);
          }
        }
      }
    }

    protected override void OnClosing(CancelEventArgs e)
    {
      CheckHighScore();
      base.OnClosing(e);
    }

    private void button1_Click(object sender, EventArgs e)
    {
      TheLetterManager = null;
      TheLetterManager = new LetterManager(TheWordManager.Pick());
      TheLetterManager.SetPosition(20, 150);
      TheLetterManager.SetMissPosition(this.ClientRectangle.Right - 200,
                                       this.ClientRectangle.Bottom - 40);
      TheWinLoseManager.Initialize();
      TheMan.NumberOfMisses = 0;
      button1.Visible = false;

      // Return Focus to the form.
      this.Focus();
      this.Invalidate();
    }
  }
}