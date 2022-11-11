using System;
using System.Drawing;
using System.Drawing.Drawing2D;
  
namespace Hangman
{
  public class Man
  {
    private Point Position = new Point(0, 0);
    public const int StandLength = 100;
    public const int StandHeight = 100;
    public const int JibLength = 75;
    public const int RopeLength = 15;
    public const int HeadDiameter = 15;
    public const int BodyLength = 30;
    public const int ArmLength = 15;
    public const int LegLength = 15;
    
    public Man()
    {
      // Nothing to see here, move along!
    }

    public void SetPosition(int x, int y)
    {
      Position.X = x;
      Position.Y = y;
    }

    public int NumberOfMisses = 0;

    public void DrawHangMan(Graphics g)
    {
      if( NumberOfMisses > 0)
      {
        // Draw Base
        g.DrawLine(new Pen(Color.Black), Position.X, Position.Y, Position.X + StandLength, Position.Y );
      }
      
      if( NumberOfMisses > 1)
      {
        // Draw upright
        g.DrawLine(new Pen(Color.Black), 
                   Position.X + StandLength/4, Position.Y, 
                   Position.X + StandLength/4, Position.Y - StandHeight );
      }
      
      if( NumberOfMisses > 2)
      {
        // Draw Base Supports
        g.DrawLine(new Pen(Color.Black), 
                   Position.X + StandLength/16, Position.Y, 
                   Position.X + StandLength/4,  Position.Y - ((StandHeight/16)*3) );
        g.DrawLine(new Pen(Color.Black), 
                   Position.X + StandLength/4,        Position.Y - ((StandHeight/16)*3),
                   Position.X + ((StandLength/16)*7), Position.Y );
      }
      
      if( NumberOfMisses > 3)
      {
        // Draw Jib
        g.DrawLine(new Pen(Color.Black), 
                   Position.X + StandLength/4, Position.Y - StandHeight,
                   Position.X + StandLength/4 + JibLength, Position.Y - StandHeight );
      }
      
      if( NumberOfMisses > 4)
      {
        // Draw Jib Support
        g.DrawLine(new Pen(Color.Black), 
                   Position.X + StandLength/4, Position.Y - ((StandHeight/16)*13),
                   Position.X + StandLength/4 + ((JibLength/12)*3), Position.Y - StandHeight );
      }
      
      if( NumberOfMisses > 5)
      {
        // Draw Rope
        g.DrawLine(new Pen(Color.Black), 
                   Position.X + StandLength/4 + JibLength, Position.Y - StandHeight,
                   Position.X + StandLength/4 + JibLength, Position.Y - StandHeight + RopeLength );
      }
      
      if( NumberOfMisses > 6)
      {
        // Draw Head
        Rectangle rect = new Rectangle(Position.X + StandLength/4 + JibLength - HeadDiameter/2, Position.Y - StandHeight + RopeLength,
                                       HeadDiameter, HeadDiameter);
        g.DrawEllipse(new Pen(Color.Red), rect);
      }
      
      if( NumberOfMisses > 7)
      {
        // Draw Body
        g.DrawLine(new Pen(Color.Red),
                   Position.X + StandLength/4 + JibLength, Position.Y - StandHeight + RopeLength + HeadDiameter,
                   Position.X + StandLength/4 + JibLength, Position.Y - StandHeight + RopeLength + HeadDiameter + BodyLength );
      }
      
      if( NumberOfMisses > 8)
      {
        // Draw Arms
        g.DrawLine(new Pen(Color.Red),
                   Position.X + StandLength/4 + JibLength - ArmLength, Position.Y - StandHeight + RopeLength + HeadDiameter + ArmLength,
                   Position.X + StandLength/4 + JibLength,             Position.Y - StandHeight + RopeLength + HeadDiameter );
        g.DrawLine(new Pen(Color.Red),
                   Position.X + StandLength/4 + JibLength,             Position.Y - StandHeight + RopeLength + HeadDiameter,
                   Position.X + StandLength/4 + JibLength + ArmLength, Position.Y - StandHeight + RopeLength + HeadDiameter + ArmLength );
      }
      
      if( NumberOfMisses > 9)
      {
        // Draw Legs
        g.DrawLine(new Pen(Color.Red),
                   Position.X + StandLength/4 + JibLength - LegLength, Position.Y - StandHeight + RopeLength + HeadDiameter + BodyLength + LegLength,
                   Position.X + StandLength/4 + JibLength,             Position.Y - StandHeight + RopeLength + HeadDiameter + BodyLength );
        g.DrawLine(new Pen(Color.Red),
                   Position.X + StandLength/4 + JibLength,             Position.Y - StandHeight + RopeLength + HeadDiameter + BodyLength,
                   Position.X + StandLength/4 + JibLength + LegLength, Position.Y - StandHeight + RopeLength + HeadDiameter + BodyLength + LegLength );
      }
    }
  }
}
