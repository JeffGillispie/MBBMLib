// <copyright file="DelegateCommand.cs" company="Jeff Gillispie">
// Copyright (c) Jeff Gillispie. All rights reserved.
// </copyright>

namespace MVVMLib
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// A delegate command.
    /// </summary>
    public class DelegateCommand : ICommand
    {
        private readonly Action<object> action;

        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateCommand"/> class.
        /// </summary>
        /// <param name="action">The action to delegate.</param>
        public DelegateCommand(Action<object> action)
        {
            this.action = action;
        }

        /// <summary>
        /// Occurs when the can execute command status is changed.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="parameter">The command parameter.</param>
        public void Execute(object parameter)
        {
            this.action(parameter);
        }

        /// <summary>
        /// Determines if the cammand can be executed.
        /// </summary>
        /// <param name="parameter">The command parameter.</param>
        /// <returns>Returns true if the command can be executed.</returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
