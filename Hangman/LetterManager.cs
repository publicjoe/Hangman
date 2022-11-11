using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;

namespace Hangman
{
  /// <summary>
  /// Manages printing out the guessed letters to the screen
  /// </summary>
  public class LetterManager 
  {
    private Point Position = new Point(20, 100);
    private Point MissPosition = new Point(100, 200);

    public void SetPosition(int x, int y)
    {
      Position.X = x;
      Position.Y = y;
    }

    public void SetMissPosition(int x, int y)
    {
      MissPosition.X = x;
      MissPosition.Y = y;
    }

    public string GetHiddenWord()
    {
      return HiddenWord;
    }

    private string HiddenWord;
    private int[] LetterList;
    private ArrayList MissLetterList;
    private Font TheFont = new Font("Courier New", 18);
    private Font TheMissFont = new Font("Courier New", 12);

    public LetterManager(string TheWord)
    {
      HiddenWord = TheWord;
      LetterList = new int[HiddenWord.Length];
      MissLetterList = new ArrayList();
      Initialize();
    }

    public int GotALetter(char TheLetter)
    {
      int LetterFound = 0;

      for( int i = 0; i < HiddenWord.Length; i++ )
      {
        if( HiddenWord[i] == TheLetter )
        {
          LetterList[i] = 1;
          LetterFound = 1;
        }
      }

      if( LetterFound == 0 )
      {
        for( int i = 0; i < MissLetterList.Count; i++ )
        {
          if( MissLetterList[i].ToString() == TheLetter.ToString() ) // already in missed letter list
          {
            return 2; // just return
          }
        }

        MissLetterList.Add(TheLetter);
      }

      return LetterFound;
    }

    public void DrawLetters(Graphics g)
    {
      int i;

      for( i = 0; i < HiddenWord.Length; i++ )
      {
        if( LetterList[i] == 1 )
        {
          g.DrawString(HiddenWord[i].ToString(), TheFont, new SolidBrush(Color.Blue), Position.X + (i* (TheFont.Size + 3)), Position.Y);
        }
        else
        {
          g.DrawString("_", TheFont, new SolidBrush(Color.Blue), Position.X + (i * (TheFont.Size + 3)), Position.Y);
        }
      }

      for( i = 0; i < MissLetterList.Count; i++ )
      {
        g.DrawString(MissLetterList[i].ToString(), TheMissFont, Brushes.Blue, MissPosition.X + (i * (TheMissFont.Size + 3)), MissPosition.Y);
      }
    }
    
    public void drawHiddenWord(Graphics g)
    {
      for( int i = 0; i < HiddenWord.Length; i++ )
      {
        g.DrawString(HiddenWord[i].ToString(), TheFont, new SolidBrush(Color.Red), Position.X + (i* (TheFont.Size + 3)), Position.Y);
      }      
    }

    public int GetNumberOfGuesses()
    {
      int count = 0;

      for( int i = 0; i < HiddenWord.Length; i ++ )
      {
        if( LetterList[i] == 1 )
        {
          count++;
        }
      }

      return count;
    }

    public void Initialize()
    {
      for( int i = 0; i < HiddenWord.Length; i++ )
      {
        LetterList.SetValue(0, i);
      }
    }
  }
}
