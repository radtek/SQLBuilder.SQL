using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLBuilder.SQL.Builder;

namespace SQLBuilder.SQL {
    /// <summary>
    /// Build Class
    /// </summary>
    public static class Build {
        /// <summary>
        /// MySql Select builder.
        /// </summary>
        /// <param name="Database">The database.</param>
        /// <param name="Schema">The schema.</param>
        /// <param name="Table">The table.</param>
        /// <param name="TableAlias">The alias of the table.</param>
        /// <returns>The instance of SelectQuery.</returns>
        public static SelectQuery Select(string Database, string Schema, string Table, string TableAlias) {
            return new SelectQuery(Database, Schema, Table, TableAlias);
        }

        /// <summary>
        /// MySql Select builder.
        /// </summary>
        /// <param name="Database">The database.</param>
        /// <param name="Schema">The schema.</param>
        /// <param name="Table">The table.</param>
        /// <returns>The instance of SelectQuery.</returns>
        public static SelectQuery Select(string Database, string Schema, string Table) {
            return new SelectQuery(Database, Schema, Table);
        }

        /// <summary>
        /// MySql Select builder.
        /// </summary>
        /// <param name="Select">The instance of SelectQuery isntance.</param>
        /// <param name="TableAlias">The alias of the table.</param>
        /// <returns>The instance of SelectQuery.</returns>
        public static SelectQuery Select(SelectQuery Select, string TableAlias) {
            return new SelectQuery(Select, TableAlias);
        }

        /// <summary>
        /// MySql Select builder.
        /// </summary>
        /// <param name="Selects">The list of instance of SelectQuery isntances.</param>
        /// <param name="TableAlias">The alias of the table.</param>
        /// <returns>The instance of SelectQuery.</returns>
        public static SelectQuery Select(List<SelectQuery> Selects, string TableAlias) {
            return new SelectQuery(Selects, TableAlias);
        }

        /// <summary>
        /// MySql Select Count builder.
        /// </summary>
        /// <param name="Database">The database.</param>
        /// <param name="Table">The table.</param>
        /// <param name="TableAlias">The alias of the table.</param>
        /// <returns>The instance of SelectCountQuery.</returns>
        public static SelectCountQuery SelectCount(string Database, string Table, string TableAlias) {
            return new SelectCountQuery(Database, Table, TableAlias);
        }

        /// <summary>
        /// MySql Select Count builder.
        /// </summary>
        /// <param name="Database">The database.</param>
        /// <param name="Table">The table.</param>
        /// <returns>The instance of SelectCountQuery.</returns>
        public static SelectCountQuery SelectCount(string Database, string Table) {
            return new SelectCountQuery(Database, Table);
        }

        /// <summary>
        /// MySql Insert builder.
        /// </summary>
        /// <param name="Database">The database.</param>
        /// <param name="Schema">The schema.</param>
        /// <param name="Table">The table.</param>
        /// <returns>The instance of InsertQuery.</returns>
        public static InsertQuery Insert(string Database, string Schema, string Table) {
            return new InsertQuery(Database, Schema, Table);
        }

        /// <summary>
        /// MySql Update builder.
        /// </summary>
        /// <param name="Database">The database.</param>
        /// <param name="Schema">The schema.</param>
        /// <param name="Table">The table.</param>
        /// <returns>The instance of UpdateQuery.</returns>
        public static UpdateQuery Update(string Database, string Schema, string Table) {
            return new UpdateQuery(Database, Schema, Table);
        }

        /// <summary>
        /// MySql Delete builder.
        /// </summary>
        /// <param name="Database">The database.</param>
        /// <param name="Schema">The schema.</param>
        /// <param name="Table">The table.</param>
        /// <returns>The instance of DeleteQuery.</returns>
        public static DeleteQuery Delete(string Database, string Schema, string Table) {
            return new DeleteQuery(Database, Schema, Table);
        }
    }
}
