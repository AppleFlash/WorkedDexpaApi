using System;
using System.Collections.Generic;
using Dexpa.Core.Model;
using Dexpa.Core.Services;
using Dexpa.Core.Utils;
using Dexpa.DTO;
using Dexpa.WebApi.Utils;

// Delete if needed
using Dexpa.Core.Model.Tracks;

namespace Dexpa.WebApi.Controllers
{
    public class TrackPointsController : ApiControllerBase
    {
        private ITrackPointService mTrackPointService;

        public TrackPointsController(ITrackPointService trackPointService)
        {
            mTrackPointService = trackPointService;
        }

        //public IList<TrackPointDTO> Get(long driverId, DateTime fromDate, DateTime toDate)
        public TrackData Get(long driverId, DateTime fromDate, DateTime toDate)
        {
           /* var fromDateUtc = TimeConverter.LocalToUtc(fromDate);
            var toDateUtc = TimeConverter.LocalToUtc(toDate);
            var point = mTrackPointService.GetAggregatedTrackPoints(driverId, fromDateUtc, toDateUtc);
            var pointDTOs = ObjectMapper.Instance.Map<IList<TrackPoint>, List<TrackPointDTO>>(point);
            return null;*/
            var data = new TrackData
            {
                Points = GetPoints(),
                OnOrderPoints = GetOnOrderPoints(),
                OrderPoints = GetOrderPoints(),
                WaitingClientPoints = GetWaitingClientPoints()
            };

            return data;
            return mTrackPointService.GetTrackerData(driverId, fromDate, toDate);
        }

        private List<WaitingClientPoint> GetWaitingClientPoints()
        {
            return new List<WaitingClientPoint>
            {
                new WaitingClientPoint
                {
                    FreeWaiting = 3,
                    PaidWaiting = 5,
                    WaitingCost = 5022,
                    PointId = 5,
                    OrderId = 1,
                    Delay = -3
                }
            };
        }

        private List<OrderPoint> GetOrderPoints()
        {
            return new List<OrderPoint>
            {
                new OrderPoint
                {
                    Date = new DateTime(2014, 1, 1, 10, 15, 30),
                    FromAddress = "Красная площадь 1555",
                    ToAddress = "Домодедово",
                    OrderId = 1,
                    PointId = 2
                },
                new OrderPoint
                {
                    Date = new DateTime(2014, 1, 1, 10, 15, 30),
                    FromAddress = "Красная площадь 1555",
                    ToAddress = "Домодедово",
                    OrderId = 1,
                    PointId = 3
                },
                new OrderPoint
                {
                    Date = new DateTime(2014, 1, 1, 10, 15, 30),
                    FromAddress = "проспект Мира 276",
                    ToAddress = "Домодедово!!!!!!!",
                    OrderId = 1,
                    PointId = 4,
                    Timestamp = DateTime.Now
                }, 
                new OrderPoint
                {
                    Date = new DateTime(2014, 1, 1, 10, 15, 30),
                    FromAddress = "проспект Мира 276",
                    ToAddress = "Домодедово!!!!!!!",
                    OrderId = 1,
                    PointId = 5,
                    Timestamp = DateTime.Now
                }
                , 
                new OrderPoint
                {
                    Date = new DateTime(2014, 1, 1, 10, 15, 30),
                    FromAddress = "проспект Мира 276",
                    ToAddress = "Домодедово!!!!!!!",
                    OrderId = 1,
                    PointId = 6,
                    Timestamp = DateTime.Now
                }, 
                new OrderPoint
                {
                    Date = new DateTime(2014, 1, 1, 10, 15, 30),
                    FromAddress = null,
                    ToAddress = null,
                    OrderId = 2,
                    PointId = 8,
                    Timestamp = DateTime.Now
                }, 
                new OrderPoint
                {
                    Date = new DateTime(2014, 1, 1, 10, 15, 30),
                    FromAddress = null,
                    ToAddress = null,
                    OrderId = 2,
                    PointId = 9,
                    Timestamp = DateTime.Now
                }
            };
        }

        private List<OnOrderPoint> GetOnOrderPoints()
        {
            return new List<OnOrderPoint>
            {
                new OnOrderPoint
                {
                    Cost = 505,
                    DistanceCity = 5.4,
                    DistanceOutCity = 0,
                    OrderId = 1,
                    PointId = 4,
                    TimeCity = 10,
                    TimeOutCity = 0
                }, 
                new OnOrderPoint
                {
                    Cost = 505,
                    DistanceCity = 5.4,
                    DistanceOutCity = 0,
                    OrderId = 1,
                    PointId = 3,
                    TimeCity = 10,
                    TimeOutCity = 0
                }, 
                new OnOrderPoint
                {
                    Cost = 505,
                    DistanceCity = 5.4,
                    DistanceOutCity = 0,
                    OrderId = 1,
                    PointId = 5,
                    TimeCity = 10,
                    TimeOutCity = 0
                }, 
                new OnOrderPoint
                {
                    Cost = 505,
                    DistanceCity = 5.4,
                    DistanceOutCity = 0,
                    OrderId = 1,
                    PointId = 6,
                    TimeCity = 10,
                    TimeOutCity = 0
                }, 
                new OnOrderPoint
                {
                    Cost = 505,
                    DistanceCity = 5.4,
                    DistanceOutCity = 0,
                    OrderId = 1,
                    PointId = 7,
                    TimeCity = 10,
                    TimeOutCity = 0
                }
            };
        }

        private List<DriverTrackPoint> GetPoints()
        {
            return new List<DriverTrackPoint>
            {
                new DriverTrackPoint
                {
                    Id = 1,
                    Direction = "СВ",
                    DriverState = DriverState.NotAvailable,
                    Latitude = 55.790265,
                    Longitude = 37.550802,
                    PointType = TrackPointType.Driving,
                    Speed = 6605,
                    Timestamp = DateTime.Now
                },
                new DriverTrackPoint
                {
                    Id = 2,
                    Direction = "СВ",
                    DriverState = DriverState.ReadyToWork,
                    Latitude = 55.790265,
                    Longitude = 37.560802,
                    PointType = TrackPointType.NewOrder,
                    Speed = 6605,
                    Timestamp = DateTime.Now
                },
                new DriverTrackPoint
                {
                    Id = 3,
                    Direction = "СВ",
                    DriverState = DriverState.Busy,
                    Latitude = 55.790265,
                    Longitude = 37.590802,
                    PointType = TrackPointType.DrivingToClient,
                    Speed = 6605,
                    Timestamp = DateTime.Now
                },
                new DriverTrackPoint
                {
                    Id = 4,
                    Direction = "СВ",
                    DriverState = DriverState.Busy,
                    Latitude = 55.790265,
                    Longitude = 37.590802,
                    PointType = TrackPointType.DrivingToClient,
                    Speed = 6605,
                    Timestamp = DateTime.Now
                },
                new DriverTrackPoint
                {
                    Id = 5,
                    Direction = "СВ",
                    DriverState = DriverState.Busy,
                    Latitude = 55.790265,
                    Longitude = 37.600802,
                    PointType = TrackPointType.WaitingClient,
                    Speed = 6606,
                    Timestamp = DateTime.Now
                },
                new DriverTrackPoint
                {
                    Id = 6,
                    Direction = "СВ",
                    DriverState = DriverState.Busy,
                    Latitude = 55.790265,
                    Longitude = 37.610802,
                    PointType = TrackPointType.TransportingClient,
                    Speed = 6607,
                    Timestamp = DateTime.Now
                }, 
                new DriverTrackPoint
                {
                    Id = 7,
                    Direction = "СВ",
                    DriverState = DriverState.ReadyToWork,
                    Latitude = 55.790265,
                    Longitude = 37.620802,
                    PointType = TrackPointType.OrderCompleted,
                    Speed = 6605,
                    Timestamp = DateTime.Now
                }, 
                new DriverTrackPoint
                {
                    Id = 8,
                    Direction = "СВ",
                    DriverState = DriverState.ReadyToWork,
                    Latitude = 55.790265,
                    Longitude = 37.630802,
                    PointType = TrackPointType.OrderCancelled,
                    Speed = 6605,
                    Timestamp = DateTime.Now
                }, 
                new DriverTrackPoint
                {
                    Id = 9,
                    Direction = "СВ",
                    DriverState = DriverState.ReadyToWork,
                    Latitude = 55.790265,
                    Longitude = 37.630802,
                    PointType = TrackPointType.OrderFailed,
                    Speed = 6605,
                    Timestamp = DateTime.Now
                }
            };
        }

        public IList<TrackPointDTO> GetDriverPositions(DateTime time)
        {
            var timeUtc = TimeConverter.LocalToUtc(time);
            var point = mTrackPointService.GetDriversPositions(timeUtc);
            var pointDTOs = ObjectMapper.Instance.Map<IList<TrackPoint>, List<TrackPointDTO>>(point);
            return pointDTOs;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                mTrackPointService.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}