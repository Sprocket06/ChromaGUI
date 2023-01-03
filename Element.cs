namespace ChromaGUI;

public abstract class Element
{
    public Vector2 Position { get; set; }
    public Size Size { get; set; }
    public Element? Parent { get; set; }
    public List<Element> Children { get; set; } = new();
    public bool InFocus { get; set; } = false;

    public Element(Vector2 pos, Size s)
    {
        Position = pos;
        Size = s;
    }

    public virtual void Draw(RenderContext ctx)
    {
    }

    public virtual void Update(float dt)
    {
    }

    public bool ContainsPoint(Vector2 point)
    {
        if (point.X >= Position.X && point.X <= (Position.X + Size.Width))
        {
            if (point.Y >= Position.Y && point.Y <= (Position.Y + Size.Height))
            {
                return true;
            }
        }

        return false;
    }

    public virtual bool OnMousePressed(MouseButtonEventArgs e)
    {
        if (ContainsPoint(e.Position)) return true;
        return false;
    }

    public virtual bool OnMouseReleased(MouseButtonEventArgs e)
    {
        if (ContainsPoint(e.Position)) return true;
        return false;
    }

    public virtual bool OnKeyPressed(KeyEventArgs e)
    {
        return false;
    }

    public virtual bool OnKeyReleased(KeyEventArgs e)
    {
        return false;
    }

    public virtual bool OnMouseMoved(MouseMoveEventArgs e)
    {
        if (ContainsPoint(e.Position)) return true;
        return false;
    }

    public virtual bool OnMouseScroll(MouseWheelEventArgs e)
    {
        return false;
    }
}