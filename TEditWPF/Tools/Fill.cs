﻿using System;
using System.ComponentModel.Composition;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TEditWPF.Common;
using TEditWPF.TerrariaWorld;
using TEditWPF.TerrariaWorld.Structures;

namespace TEditWPF.Tools
{
    [Export(typeof(ITool))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    [ExportMetadata("Order", 5)]
    public class Fill : ToolBase
    {
        public Fill()
        {
            _Image = new BitmapImage(new Uri(@"pack://application:,,,/TEditWPF;component/Tools/Images/paintcan.png"));
            _Name = "Fill";
            _Type = ToolType.Fill;
            IsActive = false;
        }

        #region Properties
        private string _Name;
        public override string Name
        {
            get { return _Name; }
        }

        private ToolType _Type;
        public override ToolType Type
        {
            get { return _Type; }
        }

        private BitmapImage _Image;
        public override BitmapImage Image
        {
            get { return _Image; }
        }

        private bool _IsActive;
        public override bool IsActive
        {
            get { return this._IsActive; }
            set
            {
                if (this._IsActive != value)
                {
                    this._IsActive = value;
                    this.RaisePropertyChanged("IsActive");
                }
            }
        }
        #endregion

        public override bool PressTool(TileMouseEventArgs e) { return false; }
        public override bool MoveTool(TileMouseEventArgs e) { return false; }
        public override bool ReleaseTool(TileMouseEventArgs e) { return false; }
        [Import]
        private ToolProperties _properties;
        public override WriteableBitmap PreviewTool()
        {
            return new WriteableBitmap(
                _properties.Size.Width,
                _properties.Size.Height,
                96,
                96,
                PixelFormats.Bgr32,
                null);
        }

        //[Import("World", typeof(World))]
        //private World _world = null;

        //public bool PreviewTool(Point[] location, World world, WriteableBitmap viewPortRegion)
        //{
        //    return false;
        //}

        //public bool UseTool(Point[] location, World world)
        //{
        //    return false;
        //}
    }
}
