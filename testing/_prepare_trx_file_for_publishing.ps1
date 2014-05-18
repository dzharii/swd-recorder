$testResultspath = $args[0]

$target = "$testResultspath\results.trx"

if (Test-Path -Path $target) {
    Remove-Item $target -Force
}

$latestFile = gci "$testResultspath\*.trx" | sort LastWriteTime | select -Last 1


Copy-Item -Path $latestFile -Destination $target -Force