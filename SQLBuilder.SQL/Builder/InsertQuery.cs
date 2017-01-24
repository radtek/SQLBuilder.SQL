using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SQLBuilder.SQL.Builder {
    /// <summary>
    /// Insert Query Builder Class
    /// </summary>
    public class InsertQuery : BaseQuery {
        #region Private Property
        private Dictionary<string, string> _Inserts { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes the database and table for the insert statement.
        /// </summary>
        /// <param name="Database">The database of the query.</param>
        /// <param name="Schema">The schema of the query.</param>
        /// <param name="Table">The table of the query.</param>
        /// <returns>The current instance of this class.</returns>
        public InsertQuery(string Database, string Schema, string Table) {
            if (Database.IsNullOrWhiteSpace()) {
                throw new ArgumentException("Database argument should not be empty.");
            }
            this._Database = Database;
            if (Schema.IsNullOrWhiteSpace()) {
                throw new ArgumentException("Schema argument should not be empty.");
            }
            this._Schema = Schema;
            if (Table.IsNullOrWhiteSpace()) {
                throw new ArgumentException("Table argument should not be empty.");
            }
            this._Table = Table;
            this._InitProperties();
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Adds a pair of field and value for the INSERT clause.
        /// </summary>
        /// <param name="Condition">The condition to check before adding the pair for the INSERT clause.</param>
        /// <param name="Field">The field to be added.</param>
        /// <param name="Value">The value of the field.</param>
        /// <returns>The current instance of this class.</returns>
        public InsertQuery SetInsert(bool Condition, string Field, object Value) {
            if (!Condition) {
                return this;
            }
            if (Field.IsNullOrWhiteSpace()) {
                throw new ArgumentException("Field argument should not be empty.");
            }
            if (Value == null || Value == DBNull.Value) {
                this._SetInsert(Field, "NULL");
            } else if (Value is bool) {
                this._SetInsert(Field, Convert.ToInt16(Value).ToString());
            } else if (this._IsNumeric(Value)) {
                this._SetInsert(Field, String.Format("'{0}'", Value.ToString()));
            } else {
                string strParameterName = String.Format("@{0}", Regex.Replace(Regex.Replace(Field, @"\W", "_"), @"(?<=\w)([A-Z])", delegate(Match m) {
                    return String.Format("{0}{1}", "_", m.Value);
                }));
                this._SetParameter(strParameterName, Value);
                this._SetInsert(Field, strParameterName);
            }
            return this;
        }

        /// <summary>
        /// Adds a pair of field and value for the INSERT clause.
        /// </summary>
        /// <param name="Field">The field to be added.</param>
        /// <param name="Value">The value of the field.</param>
        /// <returns>The current instance of this class.</returns>
        public InsertQuery SetInsert(string Field, object Value) {
            return this.SetInsert(true, Field, Value);
        }
        #endregion

        #region Public Override Method
        /// <summary>
        /// Builds the query.
        /// </summary>
        /// <returns>The query.</returns>
        /// <returns>The current instance of this class.</returns>
        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.Append(String.Format("INSERT INTO {0}.{1}.{2}", this._Database, this._Schema, this._Table));
            sb.Append(String.Format(" ({0})", String.Join("\n,", this._Inserts.Keys.Select(x => x).ToArray())));
            sb.Append(String.Format("\nVALUES ({0})", String.Join("\n,", this._Inserts.Values.ToArray())));
            return sb.ToString();
        }
        #endregion

        #region Private Method
        /// <summary>
        /// Initializes the properties.
        /// </summary>
        private void _InitProperties() {
            this._Inserts = new Dictionary<string, string>();
        }

        /// <summary>
        /// Adds the pair of field and value to the Insert dictionary.
        /// </summary>
        /// <param name="Field">The name of the parameter.</param>
        /// <param name="Value">The value of the parameter.</param>
        private void _SetInsert(string Field, string Value) {
            if (Field.IsNullOrWhiteSpace()) {
                throw new ArgumentException("Field argument should not be empty.");
            }
            if (this._Inserts.ContainsKey(Field)) {
                this._Inserts[Field] = Value;
            } else {
                this._Inserts.Add(Field, Value);
            }
        }
        #endregion
    }
}
