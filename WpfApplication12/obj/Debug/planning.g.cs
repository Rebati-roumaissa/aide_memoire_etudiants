﻿#pragma checksum "..\..\planning.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B64E663176694C74F16219500EEF31A7"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using WpfApplication12;
using WpfScheduler;


namespace WpfApplication12 {
    
    
    /// <summary>
    /// planning
    /// </summary>
    public partial class planning : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 190 "..\..\planning.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WpfScheduler.Scheduler PlanningJour;
        
        #line default
        #line hidden
        
        
        #line 201 "..\..\planning.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label;
        
        #line default
        #line hidden
        
        
        #line 202 "..\..\planning.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label_Copy;
        
        #line default
        #line hidden
        
        
        #line 216 "..\..\planning.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WpfScheduler.Scheduler PlanningSemaine;
        
        #line default
        #line hidden
        
        
        #line 227 "..\..\planning.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label_Copy1;
        
        #line default
        #line hidden
        
        
        #line 228 "..\..\planning.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label_Copy2;
        
        #line default
        #line hidden
        
        
        #line 239 "..\..\planning.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WpfScheduler.Scheduler PlanningMonth;
        
        #line default
        #line hidden
        
        
        #line 250 "..\..\planning.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label_Copy3;
        
        #line default
        #line hidden
        
        
        #line 251 "..\..\planning.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label_Copy4;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfApplication12;component/planning.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\planning.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.PlanningJour = ((WpfScheduler.Scheduler)(target));
            
            #line 190 "..\..\planning.xaml"
            this.PlanningJour.Loaded += new System.Windows.RoutedEventHandler(this.scheduler1_Loaded);
            
            #line default
            #line hidden
            
            #line 191 "..\..\planning.xaml"
            this.PlanningJour.OnEventDoubleClick += new System.EventHandler<WpfScheduler.Event>(this.Planjour_OnEventDoubleClick);
            
            #line default
            #line hidden
            
            #line 192 "..\..\planning.xaml"
            this.PlanningJour.OnScheduleDoubleClick += new System.EventHandler<System.DateTime>(this.scheduler1_OnScheduleDoubleClick);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 195 "..\..\planning.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PrevDay);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 198 "..\..\planning.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.NextDay);
            
            #line default
            #line hidden
            return;
            case 4:
            this.label = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.label_Copy = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.PlanningSemaine = ((WpfScheduler.Scheduler)(target));
            
            #line 216 "..\..\planning.xaml"
            this.PlanningSemaine.Loaded += new System.Windows.RoutedEventHandler(this.scheduler2_Loaded);
            
            #line default
            #line hidden
            
            #line 218 "..\..\planning.xaml"
            this.PlanningSemaine.OnEventDoubleClick += new System.EventHandler<WpfScheduler.Event>(this.PlanSemaine_OnEventDoubleClick);
            
            #line default
            #line hidden
            
            #line 219 "..\..\planning.xaml"
            this.PlanningSemaine.OnScheduleDoubleClick += new System.EventHandler<System.DateTime>(this.scheduler1_OnScheduleDoubleClick);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 221 "..\..\planning.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PrevWeek);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 224 "..\..\planning.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.NextWeek);
            
            #line default
            #line hidden
            return;
            case 9:
            this.label_Copy1 = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.label_Copy2 = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.PlanningMonth = ((WpfScheduler.Scheduler)(target));
            
            #line 239 "..\..\planning.xaml"
            this.PlanningMonth.Loaded += new System.Windows.RoutedEventHandler(this.scheduler3_Loaded);
            
            #line default
            #line hidden
            
            #line 241 "..\..\planning.xaml"
            this.PlanningMonth.OnEventDoubleClick += new System.EventHandler<WpfScheduler.Event>(this.PlanMois_OnEventDoubleClick);
            
            #line default
            #line hidden
            
            #line 242 "..\..\planning.xaml"
            this.PlanningMonth.OnScheduleDoubleClick += new System.EventHandler<System.DateTime>(this.scheduler1_OnScheduleDoubleClick);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 244 "..\..\planning.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PrevMonth);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 247 "..\..\planning.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.NextMonth);
            
            #line default
            #line hidden
            return;
            case 14:
            this.label_Copy3 = ((System.Windows.Controls.Label)(target));
            return;
            case 15:
            this.label_Copy4 = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

