package md5c061d5b67b2bf180a74fe23549602373;


public class MPAndroidChart
	extends android.support.v7.app.AppCompatActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Etl_Analytics_Mobile_Version_01.AllActivity.MPAndroidChart, Etl_Analytics_Mobile_Version_01, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MPAndroidChart.class, __md_methods);
	}


	public MPAndroidChart () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MPAndroidChart.class)
			mono.android.TypeManager.Activate ("Etl_Analytics_Mobile_Version_01.AllActivity.MPAndroidChart, Etl_Analytics_Mobile_Version_01, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
