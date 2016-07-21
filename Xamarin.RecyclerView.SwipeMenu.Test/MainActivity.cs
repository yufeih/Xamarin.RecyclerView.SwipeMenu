using Android.App;
using Android.Views;
using Android.Widget;
using Android.OS;
using Com.Tubb.Smrv;
using Android.Support.V7.Widget;
using System;

namespace SwipeMenuTest
{
    [Activity(Label = "Xamarin.RecyclerView.SwipeMenu.Test", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var recyclerView = FindViewById<SwipeMenuRecyclerView>(Resource.Id.listView);

            recyclerView.SetAdapter(new MyAdapter(this));
            recyclerView.SetLayoutManager(new LinearLayoutManager(this));
        }

        class MyAdapter : RecyclerView.Adapter
        {
            private readonly MainActivity _context;

            public MyAdapter(MainActivity context)
            {
                _context = context;
            }

            public override int ItemCount => 10;

            public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
            {
                var vh = (MyViewHolder)holder;
                vh.TvName.Text = position.ToString();
                vh.Sml.SwipeEnable = true;
            }

            public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
            {
                var view = LayoutInflater.From(_context).Inflate(Resource.Layout.item_simple, parent, false);

                return new MyViewHolder(view);
            }
        }

        class MyViewHolder : RecyclerView.ViewHolder
        {
            public readonly TextView TvName;
            public readonly SwipeHorizontalMenuLayout Sml;

            public MyViewHolder(View itemView) : base(itemView)
            {
                TvName = itemView.FindViewById<TextView>(Resource.Id.tvName);
                Sml = itemView.FindViewById<SwipeHorizontalMenuLayout>(Resource.Id.sml);
            }
        }
    }
}

