namespace SQLBuilder.SQL {
    /// <summary>
    /// Application Intents enum.
    /// </summary>
    public enum ApplicationIntents {
        /// <summary>
        /// Read Only value.
        /// </summary>
        ReadOnly,
        /// <summary>
        /// Read Write value.
        /// </summary>
        ReadWrite
    }

    /// <summary>
    /// Order Directions enum.
    /// </summary>
    public enum OrderDirections {
        /// <summary>
        /// Asc value.
        /// </summary>
        Asc,
        /// <summary>
        /// Desc value.
        /// </summary>
        Desc
    }

    /// <summary>
    /// Connectors enum.
    /// </summary>
    public enum Connectors {
        /// <summary>
        /// AND connector.
        /// </summary>
        And,
        /// <summary>
        /// OR connector.
        /// </summary>
        Or
    }

    /// <summary>
    /// Operators enum.
    /// </summary>
    public enum Operators {
        /// <summary>
        /// IS operator.
        /// </summary>
        Is,
        /// <summary>
        /// IS NOT operator.
        /// </summary>
        IsNot,
        /// <summary>
        /// = operator.
        /// </summary>
        Equal,
        /// <summary>
        /// != operator.
        /// </summary>
        NotEqual,
        /// <summary>
        /// > operator.
        /// </summary>
        GreaterThan,
        /// <summary>
        /// >= operator.
        /// </summary>
        GreaterThanOrEqual,
        /// <summary>
        /// &lt; operator.
        /// </summary>
        LesserThan,
        /// <summary>
        /// &lt;= operator.
        /// </summary>
        LesserThanOrEqual,
        /// <summary>
        /// IN operator.
        /// </summary>
        In,
        /// <summary>
        /// NOT IN operator.
        /// </summary>
        NotIn
    }
}
