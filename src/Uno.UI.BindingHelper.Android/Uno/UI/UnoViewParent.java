package Uno.UI;

import android.graphics.Matrix;
import android.view.*;
import android.graphics.PointF;
import android.graphics.Rect;
import android.util.Log;
import java.lang.*;
import java.lang.reflect.*;

/**
 * A view that participates in Uno's expanded gesture-consumption logic, which distinguishes between
 * 'handling' versus merely 'blocking' a touch event.
 *
 * Note: This interface is for internal use (a.k.a. package-private) and is NOT VISIBLE to the C# binding
 */
interface UnoViewParent {
//	/**
//	 * Called by a child to indicate to its parent that it is an Uno view. Normally called every time
//	 * the child receives a {@link android.view.View.dispatchTouchEvent(MotionEvent)}, and should be
//	 * reset by the owner at the beginning of its own dispatchTouchEvent().
//	 * @param value True if the child is an {@link UnoViewParent}
//	 */
//	public void setChildIsUnoViewGroup(boolean value);
//
//	/**
//	 * Called by a child from dispatchTouchEvent to indicate that it (or one of its descendants) blocked
//	 * the touch event, meaning that siblings should be prevented from consuming the event.
//	 * @param isBlockingTouchEvent True if touch event is blocked (eg because the child has a background)
//	 */
//	public void setChildBlockedTouchEvent(boolean isBlockingTouchEvent);
//
//	/**
//	 * Called by a child from dispatchTouchEvent to indicate that it (or one of its descendants) handled
//	 * the touch event.
//	 * @param isHandlingTouchEvent True if the touch event is handled (eg the child is a button)
//	 */
//	public void setChildHandledTouchEvent(boolean isHandlingTouchEvent);

	//void setChildMotionEventResult(View child, boolean isBlocking, boolean isHandling);

	// access to common managed properties of the target
	int getChildRenderTransformCount();
	Matrix findRenderTransform(View child);
	boolean getIsHitTestVisible();
	boolean nativeHitCheck(); // TODO: This should be coerced into the IsHitTestVisible()
	boolean getIsEnable();
	boolean tryRaiseNativeMotionEvent(MotionEvent event, View originalSource);
}

