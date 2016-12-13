package md5c7e6c9f134094c3c5b08d0252d45c9e0;


public class PagerSlidingTabStrip_PagerAdapterDataSetObserver
	extends android.database.DataSetObserver
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onChanged:()V:GetOnChangedHandler\n" +
			"n_onInvalidated:()V:GetOnInvalidatedHandler\n" +
			"";
		mono.android.Runtime.register ("PagerSlidingTabStrip.PagerSlidingTabStrip+PagerAdapterDataSetObserver, PagerSlidingTabStrip, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", PagerSlidingTabStrip_PagerAdapterDataSetObserver.class, __md_methods);
	}


	public PagerSlidingTabStrip_PagerAdapterDataSetObserver () throws java.lang.Throwable
	{
		super ();
		if (getClass () == PagerSlidingTabStrip_PagerAdapterDataSetObserver.class)
			mono.android.TypeManager.Activate ("PagerSlidingTabStrip.PagerSlidingTabStrip+PagerAdapterDataSetObserver, PagerSlidingTabStrip, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public PagerSlidingTabStrip_PagerAdapterDataSetObserver (md5c7e6c9f134094c3c5b08d0252d45c9e0.PagerSlidingTabStrip p0) throws java.lang.Throwable
	{
		super ();
		if (getClass () == PagerSlidingTabStrip_PagerAdapterDataSetObserver.class)
			mono.android.TypeManager.Activate ("PagerSlidingTabStrip.PagerSlidingTabStrip+PagerAdapterDataSetObserver, PagerSlidingTabStrip, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "PagerSlidingTabStrip.PagerSlidingTabStrip, PagerSlidingTabStrip, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0 });
	}


	public void onChanged ()
	{
		n_onChanged ();
	}

	private native void n_onChanged ();


	public void onInvalidated ()
	{
		n_onInvalidated ();
	}

	private native void n_onInvalidated ();

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
