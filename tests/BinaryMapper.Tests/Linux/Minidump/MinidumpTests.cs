﻿using BinaryMapper.Windows.Minidump;
using System.IO;
using Xunit;

namespace BinaryMapper.Tests.Linux.Minidump
{
    public partial class MinidumpTests
    {
        [Fact]
        public void TestMappingLinuxMinidump()
        {
            var stream = File.OpenRead(Path.Combine("Files","vic-engine-V3398-2020-04-28T20-51-34-473.dmp"));

            var minidump = new MinidumpMapper().ReadMinidump(stream);
            Assert.Equal("Linux 3.18.66 #1 SMP PREEMPT Tue Apr 30 15:52:13 PDT 2019 armv7l", minidump.SystemInfoServicePack);
            Assert.Equal("/anki/bin/vic-engine", minidump.CommandLine);
            Assert.Equal(4, minidump.CpuInfo.HardwareInfo.Count);
            Assert.Equal(4, minidump.CpuInfo.ProcessorInfo.Count);
            Assert.NotNull(minidump.LSBRelease);
            Assert.Empty(minidump.LSBRelease);
            Assert.Null(minidump.MiscInfoStream);
            Assert.Equal(56, minidump.Modules.Count);
            Assert.Equal(8, minidump.EnvironmentVariables.Count);
            Assert.Equal(40, minidump.ProcessStatus.Count);
            Assert.Equal("Qualcomm Technologies, Inc APQ8009", minidump.CpuInfo.HardwareInfo["Hardware"]);
            Assert.Equal("0000", minidump.CpuInfo.HardwareInfo["Revision"]);
            Assert.Equal("0000000000000000", minidump.CpuInfo.HardwareInfo["Serial"]);
            Assert.Equal("ARMv7 Processor rev 5 (v7l)", minidump.CpuInfo.HardwareInfo["Processor"]);
        }
    }
}
