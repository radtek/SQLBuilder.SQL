using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SQLBuilder.SQL.Builder {
    /// <summary>
    /// Update Query Builder Class
    /// </summary>
    public class UpdateQuery : BaseQuery {
        #region Private Property
        private Dictionary<string, string> _Updates { get; set; }
        private List<string> _Wheres { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes the database and table for the insert statement.
        /// </summary>
        /// <param name="Database">The database of the query.</param>
        /// <param name="Schema">The schema of the query.</param>
        /// <param name="Table">The table of the query.</param>
        public UpdateQuery(string Database, string Schema, string Table) {
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
        /// Sets a parameter to be used in the query.
        /// </summary>
        /// <param name="Name">The name of the parameter.</param>
        /// <param name="Value">The value of the parameter.</param>
        /// <returns>The current instance of this class.</returns>
        public UpdateQuery SetParameter(string Name, object Value) {
            this._SetParameter(Name, Value);
            return this;
        }

        /// <summary>
        /// Adds a pair of field and value for the UPDATE clause.
        /// </summary>
        /// <param name="Condition">The condition to check before adding the pair for the UPDATE clause.</param>
        /// <param name="Field">The field to be added.</param>
        /// <param name="Value">The value of the field.</param>
        /// <returns>The current instance of this class.</returns>
        public UpdateQuery SetUpdate(bool Condition, string Field, object Value) {
            if (!Condition) {
                return this;
            }
            if (Field.IsNullOrWhiteSpace()) {
                throw new ArgumentException("Field argument should not be empty.");
            }
            if (Value == null || Value == DBNull.Value) {
                this._SetUpdate(Field, "NULL");
            } else if (Value is bool) {
                this._SetUpdate(Field, Convert.ToInt16(Value).ToString());
            } else if (this._IsNumeric(Value)) {
                this._SetUpdate(Field, String.Format("'{0}'", Value.ToString()));
            } else {
                string strParameterName = String.Format("@{0}", Regex.Replace(Regex.Replace(Field, @"\W", "_"), @"(?<=\w)([A-Z])", delegate(Match m) {
                    return String.Format("{0}{1}", "_", m.Value);
                }));
                this._SetParameter(strParameterName, Value);
                this._SetUpdate(Field, strParameterName);
            }
            return this;
        }

        /// <summary>
        /// Adds a pair of field and value for the UPDATE clause.
        /// </summary>
        /// <param name="Field">The field to be added.</param>
        /// <param name="Value">The value of the field.</param>
        /// <returns>The current instance of this class.</returns>
        public UpdateQuery SetUpdate(string Field, object Value) {
            return this.SetUpdate(true, Field, Value);
        }

        /// <summary>
        /// Adds a condition to the WHERE clause.
        /// </summary>
        /// <param name="Condition">The condition to check before adding to the WHERE clause.</param>
        /// <param name="ConditionStatement">The condition statement/s to be added.</param>
        /// <param name="ParameterValues">The arguments to be passed for formatting a string.</param>
        /// <returns>The current instance of this class.</returns>
        public UpdateQuery SetWhere(bool Condition, string ConditionStatement, params object[] ParameterValues) {
            if (Condition) {
                if (ConditionStatement.IsNullOrWhiteSpace()) {
                    throw new ArgumentException("ConditionStatement argument should not be empty.");
                }
                List<string> lstParameters = new List<string>();
                if (ParameterValues != null && ParameterValues.Length > 0) {
                    foreach (var objParameterValue in ParameterValues) {
                        string strParameter = String.Format("@where_condition_{0}", this._Parameters.Count(kv => kv.Key.Contains("@where_condition")) + 1);
                        this._SetParameter(strParameter, objParameterValue);
                        lstParameters.Add(strParameter);
                    }
                }
                this._Wheres.Add(String.Format(ConditionStatement, lstParameters.ToArray()));
            }
            return this;
        }

        /// <summary>
        /// Adds a condition to the WHERE clause.
        /// </summary>
        /// <param name="ConditionStatement">The condition statement/s to be added.</param>
        /// <param name="ParameterValues">The arguments to be passed for formatting a string.</param>
        /// <returns>The current instance of this class.</returns>
        public UpdateQuery SetWhere(string ConditionStatement, params object[] ParameterValues) {
            return this.SetWhere(true, ConditionStatement, ParameterValues);
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
            sb.Append(String.Format("UPDATE {0}.{1}.{2}", this._Database, this._Schema, this._Table));
            sb.Append("\nSET");
            sb.Append(String.Format(" {0}", String.Join("\n,", this._Updates.Select(kv => String.Format("{0} = {1}", kv.Key, kv.Value)).ToArray())));
            if (this._Wheres.Count > 0) {
                sb.Append(String.Format("\nWHERE ({0})", String.Join("\nAND ", this._Wheres.ToArray())));
            }
            return sb.ToString();
        }
        #endregion

        #region Private Method
        /// <summary>
        /// Initializes the properties.
        /// </summary>
        private void _InitProperties() {
            this._Updates = new Dictionary<string, string>();
            this._Wheres = new List<string>();
        }

        /// <summary>
        /// Adds the pair of field and value to the Update dictionary.
        /// </summary>
        /// <param name="Field">The name of the parameter.</param>
        /// <param name="Value">The value of the parameter.</param>
        private void _SetUpdate(string Field, string Value) {
            if (Field.IsNullOrWhiteSpace()) {
                throw new ArgumentException("Field argument should not be empty.");
            }
            if (this._Updates.ContainsKey(Field)) {
                this._Updates[Field] = Value;
            } else {
                this._Updates.Add(Field, Value);
            }
        }
        #endregion
    }
}
