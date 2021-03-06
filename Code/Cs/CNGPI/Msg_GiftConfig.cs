﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CNGPI
{
    public class Msg_GiftConfig_Event : Message
    {
        public override int PID => 0x0202;
        public int CoinsPerTimes { get; set; }

        public int GameSec { get; set; }

        public int LowPower { get; set; }

        public int HightPower { get; set; }

        public int WinCoins { get; set; }

        public int WinGifts { get; set; }

        protected override void ReadData(MsgDataStream stream)
        {
            base.ReadData(stream);
            CoinsPerTimes = stream.ReadByte();
            GameSec = stream.ReadByte();
            LowPower= stream.ReadByte();
            HightPower = stream.ReadByte();
            WinCoins = stream.ReadInt16();
            WinGifts = stream.ReadInt16();
        }
        protected override void WriteData(MsgDataStream stream)
        {
            base.WriteData(stream);
             stream.WriteByte((byte)CoinsPerTimes);
            stream.WriteByte((byte)GameSec);
            stream.WriteByte((byte)LowPower);
            stream.WriteByte((byte)HightPower);
            stream.WriteInt16(WinCoins);
            stream.WriteInt16(WinGifts);
        }

        public override string ToString()
        {
            return $"娃娃机配置:每局币数:{CoinsPerTimes},游戏时间:{GameSec},弱爪力:{LowPower},强爪力:{HightPower},概率:{WinGifts}奖/{WinCoins}币";
        }
    }

    public class Msg_GiftConfig_Back : Message, IBackMsg
    {
        public override int PID => 0x0282;
        public int ErrCode { get; set; }

        protected override void ReadData(MsgDataStream stream)
        {
            base.ReadData(stream);
            ErrCode = stream.ReadInt16();
        }

        protected override void WriteData(MsgDataStream stream)
        {
            base.WriteData(stream);
            stream.WriteInt16(ErrCode);
        }

        public override string ToString()
        {
            return $"回应娃娃机配置";
        }
    }
}
