package md5c7e6c9f134094c3c5b08d0252d45c9e0;


public class PagerSlidingTabStrip_PagerSlidingTabStripState
	extends android.view.View.BaseSavedState
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_writeToParcel:(Landroid/os/Parcel;I)V:GetWriteToParcel_Landroid_os_Parcel_IHandler\n" +
			"n_InitializeCreator:()Lmd5c7e6c9f134094c3c5b08d0252d45c9e0/PagerSlidingTabStrip_PagerSlidingTabStripState_SavedStateCreator;:__export__\n" +
			"";
		mono.android.Runtime.register ("PagerSlidingTabStrip.PagerSlidingTabStrip+PagerSlidingTabStripState, PagerSlidingTabStrip, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", PagerSlidingTabStrip_PagerSlidingTabStripState.class, __md_methods);
	}


	public PagerSlidingTabStrip_PagerSlidingTabStripState (android.os.Parcel p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == PagerSlidingTabStrip_PagerSlidingTabStripState.class)
			mono.android.TypeManager.Activate ("PagerSlidingTabStrip.PagerSlidingTabStrip+PagerSlidingTabStripState, PagerSlidingTabStrip, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.OS.Parcel, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public PagerSlidingTabStrip_PagerSlidingTabStripState (android.os.Parcel p0, java.lang.ClassLoader p1) throws java.lang.Throwable
	{
		super (p0, p1);
		if (getClass () == PagerSlidingTabStrip_PagerSlidingTabStripState.class)
			mono.android.TypeManager.Activate ("PagerSlidingTabStrip.PagerSlidingTabStrip+PagerSlidingTabStripState, PagerSlidingTabStrip, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.OS.Parcel, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Java.Lang.ClassLoader, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
	}


	public PagerSlidingTabStrip_PagerSlidingTabStripState (android.os.Parcelable p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == PagerSlidingTabStrip_PagerSlidingTabStripState.class)
			mono.android.TypeManager.Activate ("PagerSlidingTabStrip.PagerSlidingTabStrip+PagerSlidingTabStripState, PagerSlidingTabStrip, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.OS.IParcelable, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	private static md5c7e6c9f134094c3c5b08d0252d45c9e0.PagerSlidingTabStrip_PagerSlidingTabStripState_SavedStateCreator CREATOR = InitializeCreator ();


	public void writeToParcel (android.os.Parcel p0, int p1)
	{
		n_writeToParcel (p0, p1);
	}

	private native void n_writeToParcel (android.os.Parcel p0, int p1);

	private static md5c7e6c9f134094c3c5b08d0252d45c9e0.PagerSlidingTabStrip_PagerSlidingTabStripState_SavedStateCreator InitializeCreator ()
	{
		return n_InitializeCreator ();
	}

	private static native md5c7e6c9f134094c3c5b08d0252d45c9e0.PagerSlidingTabStrip_PagerSlidingTabStripState_SavedStateCreator n_InitializeCreator ();

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
