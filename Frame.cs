namespace ChromaGUI;

public class Frame : Element
{
    public Frame(Vector2 pos, Size s) : base(pos, s)
    {
    }

    public override void Draw(RenderContext ctx)
    {
        RenderTransform.Translate(Position);
        foreach (Element child in Children)
        {
            child.Draw(ctx);
        }

        RenderTransform.Translate(-Position);
    }

    public override void Update(float dt)
    {
        foreach (Element child in Children)
        {
            child.Update(dt);
        }
    }

    public override bool OnMousePressed(MouseButtonEventArgs e)
    {
        bool eventConsumed = false;

        if (!base.OnMousePressed(e)) return false;

        foreach (Element child in Children)
        {
            eventConsumed = child.OnMousePressed(e);
            if (eventConsumed) break;
        }

        return eventConsumed;
    }

    public virtual bool OnMouseReleased(MouseButtonEventArgs e)
    {
        if (!base.OnMouseReleased(e)) return false;

        bool eventConsumed = false;

        foreach (Element child in Children)
        {
            eventConsumed = child.OnMouseReleased(e);
            if (eventConsumed) break;
        }

        return eventConsumed;
    }

    public virtual bool OnKeyPressed(KeyEventArgs e)
    {
        if (!InFocus) return false;

        bool eventConsumed = false;

        foreach (Element child in Children)
        {
            eventConsumed = child.OnKeyPressed(e);
            if (eventConsumed) break;
        }

        return eventConsumed;
    }

    public virtual bool OnKeyReleased(KeyEventArgs e)
    {
        if (!InFocus) return false;

        bool eventConsumed = false;

        foreach (Element child in Children)
        {
            eventConsumed = child.OnKeyReleased(e);
            if (eventConsumed) break;
        }

        return eventConsumed;
    }

    public virtual bool OnMouseMoved(MouseMoveEventArgs e)
    {
        if (!base.OnMouseMoved(e)) return false;

        bool eventConsumed = false;

        foreach (Element child in Children)
        {
            eventConsumed = child.OnMouseMoved(e);
            if (eventConsumed) break;
        }

        return eventConsumed;
    }

    public virtual bool OnMouseScroll(MouseWheelEventArgs e)
    {
        if (!InFocus) return false;

        bool eventConsumed = false;

        foreach (Element child in Children)
        {
            eventConsumed = child.OnMouseScroll(e);
            if (eventConsumed) break;
        }

        return eventConsumed;
    }
}