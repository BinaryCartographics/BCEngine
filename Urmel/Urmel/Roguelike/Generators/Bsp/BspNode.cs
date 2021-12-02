using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Urmel.Roguelike.Generators.Bsp
{
  public class BspNode
  {
    private static int minWidth = 8;
    private static int maxWidth = 20;
    private static int minHeight = 8;
    private static int maxHeight = 20;
    private readonly Random Random;
    private bool HSplit { get; set; }
    private bool VSplit { get; set; }

    public BspNode NodeA { get; private set; }
    public BspNode NodeB { get; private set; }
    public BspNode(Rectangle bounds, Random random)
    {
      Random = random;
      Bounds = bounds;

      HSplit = false;
      VSplit = false;

      NodeA = null;
      NodeB = null;

      //if (bounds.Height < minHeight || bounds.Width < minWidth)
       // Debug.WriteLine("Room too small");
    }
    public Rectangle Bounds { get; }
    public bool IsLeaf
    {
      get
      {
        return (!HSplit) && (!VSplit);
      }
    }
    public void Split()
    {
      // Attempt random split
      if ((Random.NextDouble() < 0.5) && Bounds.Width >= 2 * minWidth)
      {
        VerticalSplit();
        return;
      }
      else if (Bounds.Height >= 2 * minHeight)
      {
        Debug.WriteLine(Bounds.Height);
        HorizontalSplit();
        return;
      }

      // Force split if theres too much space.
      if (Bounds.Width > maxWidth)
      {
        VerticalSplit();
        return;
      }

      if (Bounds.Height > maxHeight)
      {
        HorizontalSplit();
        // no need to return, method bottoms out here
      }
    }
    private void HorizontalSplit()
    {
      HSplit = true;
      int split = Random.Next(minHeight, Bounds.Height - minHeight);
      Debug.WriteLine("HORIZONTAL SPLIT");
      Debug.WriteLine(" pHeight = " + Bounds.Height);
      NodeA = new BspNode(new Rectangle(Bounds.X, Bounds.Y, Bounds.Width, split), Random);
      Debug.WriteLine(" aHeight = " + NodeA.Bounds.Height); 
      NodeB = new BspNode(new Rectangle(Bounds.X, Bounds.Y + split, Bounds.Width, Bounds.Height - split), Random);
      Debug.WriteLine(" bHeight = " + NodeB.Bounds.Height);
      Debug.WriteLine(" aHeight + bHeight = " + (NodeA.Bounds.Height + NodeB.Bounds.Height));
      NodeA.Split();
      NodeB.Split();
    }
    private void VerticalSplit()
    {
      VSplit = true;

      int split = Random.Next(minWidth, Bounds.Width - minWidth);
      Debug.WriteLine("VERTICAL SPLIT");
      Debug.WriteLine(" pWidth = " + Bounds.Width);
      NodeA = new BspNode(new Rectangle(Bounds.X, Bounds.Y, split, Bounds.Height), Random);
      Debug.WriteLine(" aWidth = " + NodeA.Bounds.Width);
      NodeB = new BspNode(new Rectangle(Bounds.X + split, Bounds.Y, Bounds.Width - split, Bounds.Height), Random);
      Debug.WriteLine(" bWidth = " + NodeB.Bounds.Width);
      Debug.WriteLine(" aWidth + bWidth = " + (NodeA.Bounds.Width + NodeB.Bounds.Width));
      NodeA.Split();
      NodeB.Split();
    }
    public void GetRooms(List<Rectangle> toPopulate)
    {
      if (IsLeaf)
      {
        Rectangle r = new Rectangle(Bounds.X + 1, Bounds.Y + 1, Bounds.Width - 2, Bounds.Height - 2);
        toPopulate.Add(r);
      }
      else
      {
        NodeA.GetRooms(toPopulate);
        NodeB.GetRooms(toPopulate);
      }
    }
  }
}
