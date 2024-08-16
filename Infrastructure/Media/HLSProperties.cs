namespace Infrastructure.Media
{
   public class HLSProperties
   {
       public string Bucket { get; set; }
       public string TempDir { get; set; }
       public string BaseUrl { get; set; }
       public string Master { get; set; }
       public List<QualityProperties> Qualities { get; set; }
   }

   public class QualityProperties
   {
       public int Resolution { get; set; }
       public string SegmentName { get; set; }
       public int SegmentDuration { get; set; }
       public string VideoCodec { get; set; }
       public string VideoBitrate { get; set; }
       public string AudioCodeC { get; set; }
       public string AudioBitrate { get; set; }
       public string Scale { get; set; }
       public string Manifest { get; set; }
   }
}

