function FindProxyForURL(url, host)
{
host = host.toLowerCase();
if( isPlainHostName ( host )) return "DIRECT";
if( shExpMatch( host, "*.cloudmail.microsoft.com" )) return "PROXY hnproxy.fushan.fihnbb.com:8080";
if( shExpMatch( host, "*.fihtdc.com" )) return "PROXY hnproxy.fushan.fihnbb.com:8080";
//
//      Subnet rules new server
//
if (!isResolvable(host)) return "PROXY hnproxy.fushan.fihnbb.com:8080";
resolved_host = dnsResolve(host);
if( isInNet(resolved_host, "127.0.0.0","255.0.0.0")) return "DIRECT";
if( isInNet(resolved_host, "172.16.0.0","255.240.0.0")) return "DIRECT";
if( isInNet(resolved_host, "10.0.0.0","255.0.0.0")) return "DIRECT";
if( isInNet(resolved_host, "192.168.0.0","255.255.0.0")) return "DIRECT";
if( isInNet(resolved_host, "210.80.94.0","255.255.255.0")) return "PROXY hnproxy.fushan.fihnbb.com:8080";
if( isInNet(resolved_host, "219.90.56.0","255.255.250.0")) return "PROXY hnproxy.fushan.fihnbb.com:8080";
if( isInNet(resolved_host, "131.228.16.0","255.255.252.0")) return "PROXY hnproxy.fushan.fihnbb.com:8080";
if( isInNet(resolved_host, "131.228.29.0","255.255.255.0")) return "PROXY hnproxy.fushan.fihnbb.com:8080";
if( isInNet(resolved_host, "131.228.36.0","255.255.252.0")) return "PROXY hnproxy.fushan.fihnbb.com:8080";
if( isInNet(resolved_host, "131.228.72.0","255.255.252.0")) return "PROXY hnproxy.fushan.fihnbb.com:8080";
if( isInNet(resolved_host, "131.228.139.0","255.255.255.0")) return "PROXY hnproxy.fushan.fihnbb.com:8080";
if( isInNet(resolved_host, "131.228.152.0","255.255.248.0")) return "PROXY hnproxy.fushan.fihnbb.com:8080";
if( isInNet(resolved_host, "131.228.166.0","255.255.254.0")) return "PROXY hnproxy.fushan.fihnbb.com:8080";
if( isInNet(resolved_host, "131.228.168.0","255.255.248.0")) return "PROXY hnproxy.fushan.fihnbb.com:8080";
if( isInNet(resolved_host, "131.228.164.0","255.255.255.0")) return "PROXY hnproxy.fushan.fihnbb.com:8080";
if( isInNet(resolved_host, "131.228.172.0","255.255.255.0")) return "PROXY hnproxy.fushan.fihnbb.com:8080";
if( isInNet(resolved_host, "131.228.176.0","255.255.255.0")) return "PROXY hnproxy.fushan.fihnbb.com:8080";
if( isInNet(resolved_host, "131.228.180.0","255.255.252.0")) return "PROXY hnproxy.fushan.fihnbb.com:8080";
if( isInNet(resolved_host, "131.228.188.0","255.255.248.0")) return "PROXY hnproxy.fushan.fihnbb.com:8080";
if( isInNet(resolved_host, "131.228.196.0","255.255.252.0")) return "PROXY hnproxy.fushan.fihnbb.com:8080";
if( isInNet(resolved_host, "131.228.208.0","255.255.255.0")) return "PROXY hnproxy.fushan.fihnbb.com:8080";
if( isInNet(resolved_host, "131.228.210.0","255.255.255.0")) return "PROXY hnproxy.fushan.fihnbb.com:8080";
if( isInNet(resolved_host, "131.228.212.0","255.255.255.0")) return "PROXY hnproxy.fushan.fihnbb.com:8080";
if( isInNet(resolved_host, "131.228.214.0","255.255.255.0")) return "PROXY hnproxy.fushan.fihnbb.com:8080";
if( isInNet(resolved_host, "131.228.216.0","255.255.252.0")) return "PROXY hnproxy.fushan.fihnbb.com:8080";
if( isInNet(resolved_host, "131.228.0.0","255.255.0.0")) return "PROXY hnproxy.fushan.fihnbb.com:8080";
if( isInNet(resolved_host, "147.243.24.0","255.255.252.0")) return "PROXY hnproxy.fushan.fihnbb.com:8080";
if( isInNet(resolved_host, "147.243.56.0","255.255.252.0")) return "PROXY hnproxy.fushan.fihnbb.com:8080";
if( isInNet(resolved_host, "147.243.152.0","255.255.252.0")) return "PROXY hnproxy.fushan.fihnbb.com:8080";
if( isInNet(resolved_host, "147.243.216.0","255.255.252.0")) return "PROXY hnproxy.fushan.fihnbb.com:8080";
if( isInNet(resolved_host, "147.243.236.0","255.255.254.0")) return "PROXY hnproxy.fushan.fihnbb.com:8080";
if( isInNet(resolved_host, "147.243.0.0","255.255.0.0")) return "DIRECT";
if( isInNet(resolved_host, "93.183.10.0","255.255.255.240")) return "PROXY hnproxy.fushan.fihnbb.com:8080";
if( isInNet(resolved_host, "194.41.30.192","255.255.255.224")) return "PROXY hnproxy.fushan.fihnbb.com:8080";
if( isInNet(resolved_host, "194.41.31.0","255.255.255.192")) return "PROXY hnproxy.fushan.fihnbb.com:8080";
if( isInNet(resolved_host, "25.0.0.0","255.0.0.0")) return "DIRECT";
//
//      last resort
//
return "PROXY hnproxy.fushan.fihnbb.com:8080";
}
