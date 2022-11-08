package br.com.innovationgroup.herupu.Adapters;

import android.annotation.SuppressLint;
import android.content.Context;
import android.content.Intent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.Button;
import android.widget.GridLayout;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TextView;

import androidx.recyclerview.widget.RecyclerView;

import java.util.ArrayList;

import br.com.innovationgroup.herupu.AtividadeActivity;
import br.com.innovationgroup.herupu.R;

public class GridButtonsAdapter extends BaseAdapter {
    private ArrayList<String> list;

    @Override
    public int getCount() {
        return list.size();
    }

    @Override
    public String getItem(int i) {
        return list.get(i);
    }

    @Override
    public long getItemId(int i) {
        return (long)i;
    }

    private Context mContext;
    public GridButtonsAdapter(Context context, ArrayList<String> btnsNames) {
        this.mContext = context;
        this.list = btnsNames;
    }

    @SuppressLint("ViewHolder")
    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        // Inflate o view personalizado
        LayoutInflater inflater = (LayoutInflater) mContext.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        LinearLayout itemLayout = (LinearLayout) inflater.inflate(R.layout.btn_grid, null);

        Button cellBtn = itemLayout.findViewById(R.id.btn_qst1);

//        String name = list[position];

        cellBtn.setText("a");
        cellBtn.setTag("a");
        return cellBtn;
    }
}