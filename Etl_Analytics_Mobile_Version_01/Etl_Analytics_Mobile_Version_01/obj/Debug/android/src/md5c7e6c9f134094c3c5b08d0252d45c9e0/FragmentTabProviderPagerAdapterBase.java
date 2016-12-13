package md5c7e6c9f134094c3c5b08d0252d45c9e0;


public abstract class FragmentTabProviderPagerAdapterBase
	extends android.support.v4.app.FragmentPagerAdapter
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("PagerSlidingTabStrip.FragmentTabProviderPagerAdapterBase, PagerSlidingTabStrip, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", FragmentTabProviderPagerAdapterBase.class, __md_methods);
	}


	public FragmentTabProviderPagerAdapterBase (android.support.v4.app.FragmentManager p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == FragmentTabProviderPagerAdapterBase.class)
			mono.android.TypeManager.Activate ("PagerSlidingTabStrip.FragmentTabProviderPagerAdapterBase, PagerSlidingTabStrip, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Support.V4.App.FragmentManager, Xamarin.Android.Support.v4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0 });
	}

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
