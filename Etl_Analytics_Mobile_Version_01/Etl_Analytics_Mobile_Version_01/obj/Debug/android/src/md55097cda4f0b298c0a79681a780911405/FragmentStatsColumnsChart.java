package md55097cda4f0b298c0a79681a780911405;


public class FragmentStatsColumnsChart
	extends android.support.v4.app.Fragment
	implements
		mono.android.IGCUserPeer,
		com.github.mikephil.charting.listener.OnChartValueSelectedListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onCreateView:(Landroid/view/LayoutInflater;Landroid/view/ViewGroup;Landroid/os/Bundle;)Landroid/view/View;:GetOnCreateView_Landroid_view_LayoutInflater_Landroid_view_ViewGroup_Landroid_os_Bundle_Handler\n" +
			"n_onNothingSelected:()V:GetOnNothingSelectedHandler:MikePhil.Charting.Listener.IOnChartValueSelectedListenerSupportInvoker, MPAndroidChart\n" +
			"n_onValueSelected:(Lcom/github/mikephil/charting/data/Entry;Lcom/github/mikephil/charting/highlight/Highlight;)V:GetOnValueSelected_Lcom_github_mikephil_charting_data_Entry_Lcom_github_mikephil_charting_highlight_Highlight_Handler:MikePhil.Charting.Listener.IOnChartValueSelectedListenerSupportInvoker, MPAndroidChart\n" +
			"";
		mono.android.Runtime.register ("Etl_Analytics_Mobile_Version_01.Fragments.StatsColumnsFragments.FragmentStatsColumnsChart, Etl_Analytics_Mobile_Version_01, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", FragmentStatsColumnsChart.class, __md_methods);
	}


	public FragmentStatsColumnsChart () throws java.lang.Throwable
	{
		super ();
		if (getClass () == FragmentStatsColumnsChart.class)
			mono.android.TypeManager.Activate ("Etl_Analytics_Mobile_Version_01.Fragments.StatsColumnsFragments.FragmentStatsColumnsChart, Etl_Analytics_Mobile_Version_01, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public android.view.View onCreateView (android.view.LayoutInflater p0, android.view.ViewGroup p1, android.os.Bundle p2)
	{
		return n_onCreateView (p0, p1, p2);
	}

	private native android.view.View n_onCreateView (android.view.LayoutInflater p0, android.view.ViewGroup p1, android.os.Bundle p2);


	public void onNothingSelected ()
	{
		n_onNothingSelected ();
	}

	private native void n_onNothingSelected ();


	public void onValueSelected (com.github.mikephil.charting.data.Entry p0, com.github.mikephil.charting.highlight.Highlight p1)
	{
		n_onValueSelected (p0, p1);
	}

	private native void n_onValueSelected (com.github.mikephil.charting.data.Entry p0, com.github.mikephil.charting.highlight.Highlight p1);

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
