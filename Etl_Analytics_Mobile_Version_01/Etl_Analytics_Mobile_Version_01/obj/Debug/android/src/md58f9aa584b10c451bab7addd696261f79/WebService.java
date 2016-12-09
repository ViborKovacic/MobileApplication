package md58f9aa584b10c451bab7addd696261f79;


public class WebService
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Etl_Analytics_Mobile_Version_01.Class.WebService, Etl_Analytics_Mobile_Version_01, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", WebService.class, __md_methods);
	}


	public WebService () throws java.lang.Throwable
	{
		super ();
		if (getClass () == WebService.class)
			mono.android.TypeManager.Activate ("Etl_Analytics_Mobile_Version_01.Class.WebService, Etl_Analytics_Mobile_Version_01, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
