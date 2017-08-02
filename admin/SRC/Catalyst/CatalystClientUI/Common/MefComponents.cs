namespace Diet.Common
{
    using System;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.IO;
    using System.Reflection;

    /// <summary>
    /// MEF BusinessComponents
    /// </summary>
    internal sealed class MefComponents : IDisposable
    {
        #region Instance
        /// <summary>
        /// The instance
        /// </summary>
        private static volatile MefComponents instance;

        /// <summary>
        /// The locking object
        /// </summary>
        private static object lockingObject = new object();
        #endregion

        #region Ctor
        /// <summary>
        /// Prevents a default instance of the <see cref="MefComponents"/> class from being created.
        /// </summary>
        private MefComponents()
        {
            DirectoryCatalog catalog = new DirectoryCatalog(Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath));
            this.MEFContainer = new CompositionContainer(catalog);
            this.MEFContainer.ComposeParts();
            this.MEFContainer.ComposeParts(this);
        }
        #endregion

        #region Current Instance
        /// <summary>
        /// Gets the current.
        /// </summary>
        /// <value>
        /// The current.
        /// </value>
        public static MefComponents Current
        {
            get
            {
                if (instance == null)
                {
                    lock (lockingObject)
                    {
                        if (instance == null)
                        {
                            instance = new MefComponents();
                        }
                    }
                }

                return instance;
            }
        }
        #endregion

        /// <summary>
        /// Gets or sets the MEF container.
        /// </summary>
        /// <value>
        /// The MEF container.
        /// </value>
        public CompositionContainer MEFContainer { get; set; }

        #region Disposible
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.MEFContainer.Dispose();
            GC.SuppressFinalize(instance);
        }
        #endregion
    }
}
