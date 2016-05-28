﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundTasks.Models {
    public class AuthorQuotesCollection : ObservableKeyedCollection {
        private string _query { get; set; }

        public AuthorQuotesCollection() {
            HasMoreItems = true;
        }

        public override async Task<int> BuildAndFetch(string query = "") {
            // Checks if this is a new search
            if (query != string.Empty && query != _query) {
                Page = 1;
                HasMoreItems = true;
                RedirectedURL = "";
                Clear();
            }

            _query = query.Length > 0 ? query : _query;

            var url = _query + "?page=" + Page;
            return await Fetch(url);
        }
    }
}
