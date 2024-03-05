using System;
using System.Collections.Generic;
using Enums;
using LogicServices;
using LogicServices.Algorithm;
using Models;
using NUnit.Framework;

namespace Tests
{
    public class AlgorithmTests
    {
        // A Test behaves as an ordinary method
        [Test]
        public void CalculateRandomness_HighRandomness_ReturnsTrue()
        {
            //Given
            Random random = new Random();
            Randomness randomness = new Randomness(random);
            randomness.ChangeChance = 1;
            
            //when
            var result = randomness.Calculate();
            
            //Then
            Assert.IsTrue(result);
        }
        
        [Test]
        public void CalculateRandomness_LowRandomness_ReturnsFalse()
        {
            //Given
            Random random = new Random();
            Randomness randomness = new Randomness(random);
            randomness.ChangeChance = 0;
            
            //when
            var result = randomness.Calculate();
            
            //Then
            Assert.IsFalse(result);
        }
        
        [Test]
        public void CalculateSelfBuild_HigerThanBorder_ReturnsFalse()
        {
            //Given
            Random random = new Random();
            SelfBuild selfBuild = new SelfBuild(random);
            selfBuild.SelfBuildThreshold = 5;
            User user = new User();
            Trade trade = new Trade(InventoryItems.Wood,1,InventoryItems.Stone,1);
            
            //When
            user.Inventory.AddToInventory(InventoryItems.Wood,8);
            var result = selfBuild.Calculate(trade, user);
            
            //Then
            Assert.IsFalse(result);
        }
        
        [Test]
        public void CalculateSelfBuild_LowerThanBorder_ReturnsTrue()
        {
            //Given
            Random random = new Random();
            SelfBuild selfBuild = new SelfBuild(random);
            selfBuild.SelfBuildThreshold = 5;
            User user = new User();
            Trade trade = new Trade(InventoryItems.Wood,1,InventoryItems.Stone,1);
            
            //When
            user.Inventory.AddToInventory(InventoryItems.Wood,1);
            var result = selfBuild.Calculate(trade, user);
            
            //Then
            Assert.IsTrue(result);
        }
    }
}
