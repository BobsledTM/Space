using System;

public static class EventHandlerExtension
{
	public static void Raise(this EventHandler eventHandler, Object sender, EventArgs args)
	{
		if (eventHandler != null)
		{
			eventHandler(sender, args);
		}
	}

	public static void Raise<T>(this EventHandler<T> eventHandler, Object sender, T args) where T : EventArgs
	{
		if (eventHandler != null)
		{
			eventHandler(sender, args);
		}
	}
}