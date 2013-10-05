using System.Linq;
using System.Windows.Forms;
using FrEee.Game.Interfaces;
using FrEee.Game.Objects.Vehicles;
using FrEee.Game.Objects.Orders;
using FrEee.Utility.Extensions;
using FrEee.WinForms.Utility.Extensions;
using System.Drawing;
using FrEee.Game.Objects.Civilization;
using FrEee.Game.Objects.Commands;
using FrEee.Utility;
using FrEee.WinForms.Interfaces;
using FrEee.Game.Objects.Technology;

namespace FrEee.WinForms.Controls
{
	/// <summary>
	/// A report on a ship or base.
	/// </summary>
	public partial class SpaceVehicleReport : UserControl, IBindable<SpaceVehicle>
	{
		public SpaceVehicleReport()
		{
			InitializeComponent();
		}

		public SpaceVehicleReport(SpaceVehicle vehicle)
		{
			InitializeComponent();
			Vehicle = vehicle;
		}

		private SpaceVehicle vehicle;
		public SpaceVehicle Vehicle { get { return vehicle; } set { vehicle = value; Bind(); } }

		private void btnOrderToTop_Click(object sender, System.EventArgs e)
		{
			var order = (IOrder<SpaceVehicle>)lstOrdersDetail.SelectedItem;
			if (order != null)
			{
				var cmd = new RearrangeOrdersCommand<SpaceVehicle>(
					Empire.Current, vehicle, order, -vehicle.Orders.IndexOf(order));
				Empire.Current.Commands.Add(cmd);
				cmd.Execute(); // show change locally
				Bind();

				if (OrdersChanged != null)
					OrdersChanged();
			}
		}

		private void btnOrderToBottom_Click(object sender, System.EventArgs e)
		{
			var order = (IOrder<SpaceVehicle>)lstOrdersDetail.SelectedItem;
			if (order != null)
			{
				var cmd = new RearrangeOrdersCommand<SpaceVehicle>(
					Empire.Current, vehicle, order, Vehicle.Orders.Count - vehicle.Orders.IndexOf(order) - 1);
				Empire.Current.Commands.Add(cmd);
				cmd.Execute(); // show change locally
				Bind();

				if (OrdersChanged != null)
					OrdersChanged();
			}
		}

		private void btnOrderGoesUp_Click(object sender, System.EventArgs e)
		{
			var order = (IOrder<SpaceVehicle>)lstOrdersDetail.SelectedItem;
			if (order != null && vehicle.Orders.IndexOf(order) > 0)
			{
				var cmd = new RearrangeOrdersCommand<SpaceVehicle>(
					Empire.Current, vehicle, order, -1);
				Empire.Current.Commands.Add(cmd);
				cmd.Execute(); // show change locally
				Bind();

				if (OrdersChanged != null)
					OrdersChanged();
			}
			if (OrdersChanged != null)
				OrdersChanged();
		}

		private void btnOrderGoesDown_Click(object sender, System.EventArgs e)
		{
			var order = (IOrder<SpaceVehicle>)lstOrdersDetail.SelectedItem;
			if (order != null && vehicle.Orders.IndexOf(order) < vehicle.Orders.Count - 1)
			{
				var cmd = new RearrangeOrdersCommand<SpaceVehicle>(
					Empire.Current, vehicle, order, 1);
				Empire.Current.Commands.Add(cmd);
				cmd.Execute(); // show change locally
				Bind();

				if (OrdersChanged != null)
					OrdersChanged();
			}
		}

		private void btnClearOrders_Click(object sender, System.EventArgs e)
		{
			foreach (var order in vehicle.Orders.ToArray())
			{
				var addCmd = Empire.Current.Commands.OfType<AddOrderCommand<SpaceVehicle>>().SingleOrDefault(c => c.Order == order);
				if (addCmd == null)
				{
					// not a newly added order, so create a remove command to take it off the server
					var remCmd = new RemoveOrderCommand<SpaceVehicle>(Empire.Current, Vehicle, order);
					Empire.Current.Commands.Add(remCmd);
					remCmd.Execute(); // show change locally
				}
				else
				{
					// a newly added order, so just get rid of the add command
					Empire.Current.Commands.Remove(addCmd);
					addCmd.Execute(); // show change locally
				}
				
				Bind();

				if (OrdersChanged != null)
					OrdersChanged();
			}
		}

		private void btnDeleteOrder_Click(object sender, System.EventArgs e)
		{
			var order = (IOrder<SpaceVehicle>)lstOrdersDetail.SelectedItem;
			if (order != null)
			{
				var addCmd = Empire.Current.Commands.OfType<AddOrderCommand<SpaceVehicle>>().SingleOrDefault(c => c.Order == order);
				if (addCmd == null)
				{
					// not a newly added order, so create a remove command to take it off the server
					var remCmd = new RemoveOrderCommand<SpaceVehicle>(Empire.Current, Vehicle, order);
					Empire.Current.Commands.Add(remCmd);
					remCmd.Execute(); // show change locally
				}
				else
				{
					// a newly added order, so just get rid of the add command
					Empire.Current.Commands.Remove(addCmd);
					addCmd.Execute(); // show change locally
				}

				Bind();

				if (OrdersChanged != null)
					OrdersChanged();
			}
		}

		public delegate void OrdersChangedDelegate();

		public event OrdersChangedDelegate OrdersChanged;

		public void Bind(SpaceVehicle data)
		{
			Vehicle = data;
			Bind();
		}

		public void Bind()
		{
			if (vehicle == null)
				Visible = false;
			else
			{
				// pictures
				picOwnerFlag.Image = vehicle.Owner.Icon;
				picPortrait.Image = vehicle.Portrait;

				// name and stuff
				txtName.Text = vehicle.Name;
				txtRole.Text = vehicle.Design.Role;
				txtClass.Text = vehicle.Design.Name;
				txtSize.Text = vehicle.Design.Hull.Name + " (" + vehicle.Design.Hull.Size.Kilotons() + ")";
				txtMovement.Text = vehicle.MovementRemaining + " / " + vehicle.Speed;
				progMovement.Maximum = vehicle.Design.Speed;
				progMovement.Value = vehicle.MovementRemaining;

				// supplies and stuff
				progSupplies.Maximum = vehicle.Design.SupplyStorage;
				progSupplies.Value = vehicle.SupplyRemaining;
				// will we even use ammo/fuel?
				progAmmunition.Visible = false;
				progFuel.Visible = false;

				// damage
				// TODO - let ships take damage
				progShields.Maximum = vehicle.ShieldHitpoints;
				progShields.Value = progShields.Maximum;
				progArmor.Maximum = vehicle.ArmorHitpoints;
				progArmor.Value = progArmor.Maximum;
				progHull.Maximum = vehicle.HullHitpoints;
				progHull.Value = progHull.Maximum;

				// orders and stuff
				txtOrder.Text = vehicle.Orders.Any() ? vehicle.Orders.First().ToString() : "None";
				txtExperience.Text = "None"; // TODO - crew XP
				txtFleet.Text = "None"; // TODO - fleets

				// maintenance
				resMaintMin.Amount = vehicle.MaintenanceCost[Resource.Minerals];
				resMaintOrg.Amount = vehicle.MaintenanceCost[Resource.Organics];
				resMaintRad.Amount = vehicle.MaintenanceCost[Resource.Radioactives];

				// component summary
				txtComponentsFunctional.Text = vehicle.Components.Where(c => !c.IsDestroyed).Count() + " / " + vehicle.Components.Count + " functional";
				lstComponentsSummary.Initialize(32, 32);
				foreach (var g in vehicle.Components.GroupBy(c => c.Template))
				{
					var text = g.Any(c => c.IsDestroyed) ? g.Where(c => !c.IsDestroyed).Count() + " / " + g.Count() : g.Count().ToString();
					lstComponentsSummary.AddItemWithImage(g.Key.ComponentTemplate.Group, text, g, g.First().Template.Icon);
				}

				// cargo summary
				txtCargoSpaceFree.Text = string.Format("{0} / {1} free", (Vehicle.CargoStorage - (Vehicle.Cargo == null ? 0 : Vehicle.Cargo.Size)).Kilotons(), Vehicle.CargoStorage.Kilotons());
				lstCargoSummary.Initialize(32, 32);
				foreach (var ug in Vehicle.Cargo.Units.GroupBy(u => u.Design))
					lstCargoSummary.AddItemWithImage(ug.Key.VehicleTypeName, ug.Count() + "x " + ug.Key.Name, ug, ug.First().Icon);
				foreach (var pop in Vehicle.Cargo.Population)
					lstCargoSummary.AddItemWithImage("Population", pop.Value.ToUnitString(true) + " " + pop.Key.Name, pop, pop.Key.Icon);

				// orders detail
				lstOrdersDetail.Items.Clear();
				foreach (var o in vehicle.Orders)
					lstOrdersDetail.Items.Add(o);

				// component detail
				txtComponentsFunctionalDetail.Text = vehicle.Components.Where(c => !c.IsDestroyed).Count() + " / " + vehicle.Components.Count + " functional";
				lstComponentsDetail.Initialize(32, 32);
				foreach (var g in vehicle.Components.GroupBy(c => new ComponentGroup(c.Template, c.Hitpoints)))
				{
					if (g.Count() > 1)
						lstComponentsDetail.AddItemWithImage(g.Key.Template.ComponentTemplate.Group, g.Count() + "x " + g.Key.Template.Name + " (" + g.Key.Hitpoints + " / " + g.Key.Template.Durability + " HP)", g.Key, g.First().Icon);
					else
						lstComponentsDetail.AddItemWithImage(g.Key.Template.ComponentTemplate.Group, g.Key.Template.Name + " (" + g.Key.Hitpoints + " / " + g.Key.Template.Durability + " HP)", g.Key, g.First().Icon);
				}

				// cargo detail
				txtCargoSpaceFreeDetail.Text = string.Format("{0} / {1} free", (Vehicle.CargoStorage - Vehicle.Cargo.Size).Kilotons(), Vehicle.CargoStorage.Kilotons());
				lstCargoDetail.Initialize(32, 32);
				foreach (var ug in Vehicle.Cargo.Units.GroupBy(u => u.Design))
					lstCargoDetail.AddItemWithImage(ug.Key.VehicleTypeName, ug.Count() + "x " + ug.Key.Name, ug, ug.First().Icon);
				foreach (var pop in Vehicle.Cargo.Population)
					lstCargoDetail.AddItemWithImage("Population", pop.Value.ToUnitString(true) + " " + pop.Key.Name, pop, pop.Key.Icon);

				// abilities
				abilityTreeView.Abilities = Vehicle.UnstackedAbilities.StackToTree();
				abilityTreeView.IntrinsicAbilities = Vehicle.IntrinsicAbilities.Concat(Vehicle.Design.Hull.Abilities).Concat(Vehicle.Components.Where(c => !c.IsDestroyed).SelectMany(c => c.Abilities));
			}
		}

		private void lstComponentsSummary_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				var item = lstComponentsSummary.GetItemAt(e.X, e.Y);
				if (item != null)
				{
					var g = (IGrouping<MountedComponentTemplate, Component>)item.Tag;
					var mct = g.Key;
					var form = new ComponentReport(mct).CreatePopupForm(mct.Name);
					form.ShowDialog();
				}
			}
		}

		private void lstComponentsDetail_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				var item = lstComponentsDetail.GetItemAt(e.X, e.Y);
				if (item != null)
				{
					var g = (ComponentGroup)item.Tag;
					var form = new ComponentReport(g.SampleComponent).CreatePopupForm(g.Template.Name);
					form.ShowDialog();
				}
			}
		}

		private class ComponentGroup
		{
			public ComponentGroup(MountedComponentTemplate mct, int hitpoints)
			{
				Template = mct;
				Hitpoints = hitpoints;
			}

			public MountedComponentTemplate Template
			{
				get;
				private set;
			}

			public int Hitpoints
			{
				get;
				private set;
			}

			public static bool operator ==(ComponentGroup g1, ComponentGroup g2)
			{
				return g1.Template == g2.Template && g1.Hitpoints == g2.Hitpoints;
			}

			public static bool operator !=(ComponentGroup g1, ComponentGroup g2)
			{
				return !(g1 == g2);
			}

			public override bool Equals(object obj)
			{
				if (obj is ComponentGroup)
				{
					var g = (ComponentGroup)obj;
					return this == g;
				}
				return false;
			}

			public override int GetHashCode()
			{
				return Template.GetHashCode() ^ Hitpoints.GetHashCode();
			}

			public Component SampleComponent
			{
				get
				{
					var c = new Component(Template);
					c.Hitpoints = Hitpoints;
					return c;
				}
			}
		}
	}
}