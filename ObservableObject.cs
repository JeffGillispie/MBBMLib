// <copyright file="ObservableObject.cs" company="Jeff Gillispie">
// Copyright (c) Jeff Gillispie. All rights reserved.
// </copyright>

namespace MVVMLib
{
    using System.ComponentModel;

    /// <summary>
    /// An observable object.
    /// </summary>
    public class ObservableObject : INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when a property is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Called to send notification that a property has changed.
        /// </summary>
        /// <param name="propertyName">The name of the changed property.</param>
        protected void OnPropertyChanged(string propertyName)
        {
            var args = new PropertyChangedEventArgs(propertyName);
            this.PropertyChanged?.Invoke(this, args);
        }
    }
}
