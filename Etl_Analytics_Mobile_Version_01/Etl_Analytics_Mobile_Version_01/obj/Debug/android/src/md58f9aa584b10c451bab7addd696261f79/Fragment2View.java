package md58f9aa584b10c451bab7addd696261f79;


public class Fragment2View
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Etl_Analytics_Mobile_Version_01.Class.Fragment2View, Etl_Analytics_Mobile_Version_01, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", Fragment2View.class, __md_methods);
	}


	public Fragment2View (android.view.View p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == Fragment2View.class)
			mono.android.TypeManager.Activate ("Etl_Analytics_Mobile_Version_01.Class.Fragment2View, Etl_Analytics_Mobile_Version_01, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Views.View, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
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
