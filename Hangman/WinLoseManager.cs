using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Hangman
{
  /// <summary>
  ///  Class for Managing Wins of Losses of the game
  /// </summary>
  public class WinLoseManager
  {
    const int AllowableMisses = 10;

    private bool m_bWinFlag = false;
    public bool YouWinFlag
    {
      get { return m_bWinFlag; }
      set { m_bWinFlag = value; }
    }
    
    private bool m_bLoseFlag = false;
    public bool YouLoseFlag
    {
      get { return m_bLoseFlag; }
      set { m_bLoseFlag = value; }
    }

    public WinLoseManager()
    {
    }

    public void YouLose(Graphics g) 
    {
      g.DrawString("You Lose!", new Font("Arial", 12), new SolidBrush(Color.Blue), 200, 70);
    }

    public void YouWin(Graphics g) 
    {
      g.DrawString("You Win!", new Font("Arial", 12), new SolidBrush(Color.Blue), 200, 70);
    }

    public bool CheckForWin(int count, string strWord)
    {
      if (count >= strWord.Length)
      {
        return true;
      }

      return false;
    }

    public bool CheckForLoss(int nMisses)
    {
      if (nMisses >= AllowableMisses)
      {
        return true;
      }

      return false;
    }

    public void Initialize()
    {
      YouWinFlag = false;
      YouLoseFlag = false;
    }
  }
}
