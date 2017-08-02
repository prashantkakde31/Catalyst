namespace Diet.Common
{
    using System;

    /// <summary>
    /// This delegate describes the method on the interface to be called.
    /// </summary>
    /// <typeparam name="T">This is the type of the interface</typeparam>
    /// <param name="proxy">This is the method.</param>
    public delegate void UseServiceDelegate<T>(T proxy);

    /// <summary>
    /// Service Helper static class for accessing Business Component
    /// </summary>
    /// <typeparam name="T">Generic Type</typeparam>
    public static class BusinessHelper<T>
    {
        /// <summary>
        /// Uses the specified code block del.
        /// </summary>
        /// <param name="codeBlockDel">The code block del.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes", Justification = "No need to create static class")]
        public static void Use(UseServiceDelegate<T> codeBlockDel)
        {
            try
            {
                if (codeBlockDel != null)
                {
                    codeBlockDel(BusinessFactory());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets the MEF factory.
        /// </summary>
        /// <returns>
        /// The MEF Factory
        /// </returns>
        private static T BusinessFactory()
        {
            var concrete = MefComponents.Current.MEFContainer.GetExport<T>();
            return concrete.Value;
        }
    }
   
}
