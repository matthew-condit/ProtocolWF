﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.ProtocolManager.Controllers;
using Toxikon.ProtocolManager.Models;
using Toxikon.ProtocolManager.Views.Protocols;

namespace Toxikon.ProtocolManager.Interfaces
{
    public interface IHistoryView
    {
        void SetController(HistoryController controller);
        void AddItemToRequestedByComboBox(ListItem item);
        void SetRequestedByComboBox_SelectedIndex(int index);
        void AddItemToListView(ProtocolRequest request);

        ProtocolRequestReadOnlyView GetRequestView { get; }
    }
}